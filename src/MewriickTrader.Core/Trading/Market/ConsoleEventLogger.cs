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

            this.marketListenerSubscription = this.marketListener.TimeBarUpdated.Subscribe(OnTimeBarUpdated);
            this.marketChartSubscription = this.marketChart.TimeBarAdded.Subscribe(OnTimeBarAdded);
        }

        public void OnTimeBarAdded(ICandle timeBar)
        {
            Console.WriteLine($"TimeBarAdded: {timeBar}");
        }

        public void OnTimeBarUpdated(IQuote quoteUpdated)
        {
            Console.WriteLine($"LastTimeBarUpdated: {quoteUpdated}");
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
