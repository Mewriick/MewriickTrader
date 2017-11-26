using MewriickTrader.Core.Trading.Market;
using MewriickTrader.Core.Trading.Strategy;
using System;

namespace MewriickTrader.Core.Trading
{
    public class ForexStrategyTrader : ITrader
    {
        private bool disposed = false;

        private ITradingStrategy tradingStrategy;
        private IMarketEventsLogger marketEventsLogger;

        public ForexStrategyTrader(ITradingStrategy tradingStrategy, IMarketEventsLogger marketEventsLogger)
        {
            this.tradingStrategy = tradingStrategy ?? throw new ArgumentNullException(nameof(tradingStrategy));
            this.marketEventsLogger = marketEventsLogger ?? throw new ArgumentNullException(nameof(marketEventsLogger));
        }

        public void StartTrading()
        {
            tradingStrategy.StartListeningMarket();
        }

        public void StopTrading()
        {
            tradingStrategy.StopListeningMarket();
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
                tradingStrategy.Dispose();
            }

            disposed = true;
        }
    }
}
