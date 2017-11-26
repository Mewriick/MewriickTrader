using MtApi;
using Prism.Mvvm;
using System;

namespace MewriickTrader.Client.ViewModels
{
    public class StatusBarViewModel : BindableBase
    {
        private MtApiClient metaTraderProvider;

        public MtConnectionState ConnectionState
        {
            get { return connectionState; }
            set { SetProperty(ref connectionState, value); }
        }

        private MtConnectionState connectionState;

        public StatusBarViewModel(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
            this.metaTraderProvider.ConnectionStateChanged += MetaTraderProviderConnectionStateChanged;
        }

        private void MetaTraderProviderConnectionStateChanged(object sender, MtConnectionEventArgs e)
        {
            ConnectionState = e.Status;
        }
    }
}
