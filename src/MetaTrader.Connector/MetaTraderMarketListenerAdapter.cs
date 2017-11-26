using MewriickTrader.Core.Trading.Market;
using MtApi;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MetaTrader.Connector
{
    public class MetaTraderMarketListenerAdapter : IMarketListener
    {
        private bool disposed = false;
        private MtApiClient metaTraderProvider;

        private Subject<IQuote> quotedUpdated;

        public IObservable<IQuote> TimeBarUpdated => quotedUpdated.AsObservable();

        public MetaTraderMarketListenerAdapter(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
            this.metaTraderProvider.QuoteUpdated += FireOnQuotedUpdated;
            this.quotedUpdated = new Subject<IQuote>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                metaTraderProvider.QuoteUpdated -= FireOnQuotedUpdated;
                quotedUpdated.Dispose();
            }

            disposed = true;
        }

        private void FireOnQuotedUpdated(object sender, string symbol, double bid, double ask)
        {
            quotedUpdated.OnNext(
                new Quote(symbol, Convert.ToDecimal(bid), Convert.ToDecimal(ask)));
        }
    }
}
