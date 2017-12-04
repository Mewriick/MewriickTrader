using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading.Charts;
using MewriickTrader.Core.Trading.Market;
using System;

namespace MewriickTrader.Core.Trading.Strategy
{
    public abstract class TradingStrategy : ITradingStrategy
    {
        private bool timeBarUpdatedSubscriptionDisposed;
        private bool timeBarClosedSubscriptionDisposed;
        private bool disposed = false;

        private IDisposable timeBarUpdatedSubscription;
        private IDisposable timeBarClosedSubscription;

        protected IMarketTimerBars timeBarsListener;
        protected IMarketListener marketListener;

        public bool SubscribeOnlyOnBarClose { get; set; } = true;


        public TradingStrategy(IMarketTimerBars timeBarsListener, IMarketListener marketListener)
        {
            this.timeBarsListener = timeBarsListener ?? throw new ArgumentNullException(nameof(timeBarsListener));
            this.marketListener = marketListener ?? throw new ArgumentNullException(nameof(marketListener));
        }

        public void StartListeningMarket()
        {
            timeBarUpdatedSubscription = timeBarsListener.TimeBarAdded.Subscribe(OnTimeBarClosed);
            timeBarUpdatedSubscriptionDisposed = false;

            if (!SubscribeOnlyOnBarClose)
            {
                timeBarClosedSubscription = marketListener.TimeBarUpdated.Subscribe(OnTimeBarUpdate);
                timeBarClosedSubscriptionDisposed = false;
            }
        }

        public void StopListeningMarket()
        {
            timeBarUpdatedSubscription.Dispose();
            timeBarUpdatedSubscriptionDisposed = true;

            if (timeBarClosedSubscription != null)
            {
                timeBarClosedSubscription.Dispose();
                timeBarClosedSubscriptionDisposed = true;
            }
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

                if (!timeBarClosedSubscriptionDisposed)
                {
                    timeBarClosedSubscription?.Dispose();
                }
            }

            disposed = true;
        }

        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// Strategy exit rules (for quickier possibility to react)
        /// </summary>
        public virtual void OnTimeBarUpdate(IQuote quote)
        {
            throw new NotImplementedException($"You set property {nameof(SubscribeOnlyOnBarClose)} to True, you must override method {nameof(OnTimeBarUpdate)}" +
                $" for handling every market tick");
        }

        /// <summary>
        /// Called when time bar is closed
        /// Strategy enter/exit/filtering rules
        /// </summary>
        public abstract void OnTimeBarClosed(ICandle timeBar);

    }
}
