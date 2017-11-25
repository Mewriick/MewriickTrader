using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading;
using MewriickTrader.Core.Trading.Events;
using MtApi;
using System;

namespace MetaTrader.Connector
{
    public class ForexMarketListenerAdapter : IMarketListener
    {
        private MtApiClient metaTraderProvider;

        public ForexMarketListenerAdapter(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));

            this.metaTraderProvider.OnLastTimeBar += FireOnLastTimeBar;
        }

        private void FireOnLastTimeBar(object sender, TimeBarArgs e)
        {
            var lastCandleEventArgs = new LastCandleEventArgs(new Candle(1m, 1m, 1m, 1m, DateTime.Now));

            OnLastCandle?.Invoke(sender, lastCandleEventArgs);
        }

        public event EventHandler<LastCandleEventArgs> OnLastCandle;
    }
}
