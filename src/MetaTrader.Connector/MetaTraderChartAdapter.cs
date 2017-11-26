using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading.Charts;
using MtApi;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MetaTrader.Connector
{
    public class MetaTraderChartAdapter : IMarketChart
    {
        private bool disposed = false;
        private MtApiClient metaTraderProvider;
        private Subject<ICandle> lastCandeAdded;
        private ICandlesCollection candles;
        private int lastCandleIndex;

        public IObservable<ICandle> TimeBarAdded => lastCandeAdded.AsObservable();

        public ICandlesCollection Candles => candles;

        public ICandle LastCandle => candles[lastCandleIndex];

        public string Symbol => throw new NotImplementedException();

        public MetaTraderChartAdapter(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
            this.lastCandeAdded = new Subject<ICandle>();
            this.candles = new CandleCollection();
            this.lastCandleIndex = 0;

            this.metaTraderProvider.OnLastTimeBar += FireOnLastTimeBar;
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
                metaTraderProvider.OnLastTimeBar -= FireOnLastTimeBar;
                lastCandeAdded.Dispose();
            }

            disposed = true;
        }

        private void FireOnLastTimeBar(object sender, TimeBarArgs e)
        {
            var timeBar = e.TimeBar;
            var candle = new Candle(
                                Convert.ToDecimal(timeBar.Open),
                                Convert.ToDecimal(timeBar.High),
                                Convert.ToDecimal(timeBar.Low),
                                Convert.ToDecimal(timeBar.Close),
                                timeBar.CloseTime);

            candles.Add(candle);
            lastCandleIndex++;

            lastCandeAdded.OnNext(candle);
        }
    }
}
