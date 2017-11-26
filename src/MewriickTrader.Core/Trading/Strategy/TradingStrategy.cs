using MewriickTrader.Core.Trading.Market;
using System;

namespace MewriickTrader.Core.Trading.Strategy
{
    public abstract class TradingStrategy : ITradingStrategy
    {
        private bool timeBarUpdatedSubscriptionDisposed;
        private bool disposed = false;

        private IDisposable timeBarUpdatedSubscription;

        protected IMarketListener marketListener;


        public TradingStrategy(IMarketListener marketListener)
        {
            this.marketListener = marketListener;
        }

        public void StartListeningMarket()
        {
            timeBarUpdatedSubscription = marketListener.TimeBarUpdated.Subscribe(OnTimeBarUpdate);
            timeBarUpdatedSubscriptionDisposed = false;
        }

        public void StopListeningMarket()
        {
            timeBarUpdatedSubscription.Dispose();
            timeBarUpdatedSubscriptionDisposed = true;
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
                if (!timeBarUpdatedSubscriptionDisposed)
                {
                    timeBarUpdatedSubscription.Dispose();
                }
            }

            disposed = true;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// Suited for strategy enter/exit/filtering rules
        /// </summary>
        public abstract void OnTimeBarUpdate(IQuote quoteInfo);
    }
}
