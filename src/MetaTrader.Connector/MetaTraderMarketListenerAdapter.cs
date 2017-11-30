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
            this.metaTraderProvider.QuoteUpdate += FireOnQuotedUpdated;
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
                metaTraderProvider.QuoteUpdate -= FireOnQuotedUpdated;
                quotedUpdated.Dispose();
            }

            disposed = true;
        }

        private void FireOnQuotedUpdated(object sender, MtQuoteEventArgs mtQuoteEventArgs)
        {
            if (mtQuoteEventArgs?.Quote == null)
            {
                return;
            }

            quotedUpdated.OnNext(
                new Quote(mtQuoteEventArgs.Quote.Instrument, Convert.ToDecimal(mtQuoteEventArgs.Quote.Bid), Convert.ToDecimal(mtQuoteEventArgs.Quote.Ask)));
        }
    }
}
