using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading.Charts;
using System;

namespace MewriickTrader.Core.Trading.Market
{
    public class ConsoleEventLogger : IMarketEventsLogger
    {
        private bool disposed = false;

        private IMarketListener marketListener;
        private IMarketTimerBars marketChart;

        private IDisposable marketListenerSubscription;
        private IDisposable marketChartSubscription;

        public ConsoleEventLogger(IMarketListener marketListener, IMarketTimerBars marketChart)
        {
            this.marketListener = marketListener ?? throw new ArgumentNullException(nameof(marketListener));
            this.marketChart = marketChart ?? throw new ArgumentNullException(nameof(marketChart));
        }

        public void OnTimeBarAdded(ICandle timeBar)
        {
            Console.WriteLine($"TimeBarAdded: {timeBar}");
        }

        public void OnTimeBarUpdated(IQuote quoteUpdated)
        {
            Console.WriteLine($"LastTimeBarUpdated: {quoteUpdated}");
        }

        public void StartLogging()
        {
            marketListenerSubscription = marketListener.TimeBarUpdated.Subscribe(OnTimeBarUpdated);
            marketChartSubscription = marketChart.TimeBarAdded.Subscribe(OnTimeBarAdded);
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
                marketListenerSubscription.Dispose();
                marketChartSubscription.Dispose();
            }

            disposed = true;
        }
    }
}
