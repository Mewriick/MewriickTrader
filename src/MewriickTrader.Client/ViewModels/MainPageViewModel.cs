using MewriickTrader.Core.Trading.Market;
using MtApi;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace MewriickTrader.Client.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private MtApiClient metaTraderProvider;
        private IMarketEventsLogger marketEventsLogger;

        private string port;
        private bool notConnected;

        public string Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }

        public bool NotConnected
        {
            get { return notConnected; }
            set { SetProperty(ref notConnected, value); }
        }

        public ICommand ConnectMetaTraderCommand { get; private set; }

        public MainPageViewModel(MtApiClient metaTraderProvider, IMarketEventsLogger marketEventsLogger)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
            this.marketEventsLogger = marketEventsLogger ?? throw new ArgumentNullException(nameof(marketEventsLogger));

            this.metaTraderProvider.ConnectionStateChanged += ProviderConnectionStateChanged;

            ConnectMetaTraderCommand = new DelegateCommand(() => ConnectMetaTrader());
            NotConnected = true;
        }

        private void ConnectMetaTrader()
        {
            if (int.TryParse(Port, out var portNumber))
            {
                metaTraderProvider.BeginConnect(portNumber);
            }
        }

        private void ProviderConnectionStateChanged(object sender, MtConnectionEventArgs e)
        {
            switch (e.Status)
            {
                case MtConnectionState.Connected:
                    NotConnected = false;
                    marketEventsLogger.StartLogging();
                    break;
                case MtConnectionState.Disconnected:
                case MtConnectionState.Failed:
                    NotConnected = true;
                    break;
            }
        }
    }
}
