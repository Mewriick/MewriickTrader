using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading.Charts;
using MtApi;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MetaTrader.Connector
{
    public class MetaTraderTimeBarsAdapter : IMarketTimerBars
    {
        private bool disposed = false;
        private MtApiClient metaTraderProvider;
        private Subject<ICandle> lastCandeAdded;
        private ICandlesCollection timesBarCollection;
        private int lastCandleIndex;

        public IObservable<ICandle> TimeBarAdded => lastCandeAdded.AsObservable();

        public ICandlesCollection TimeBars => timesBarCollection;

        public ICandle ListTimeBar => timesBarCollection[lastCandleIndex];

        public string Symbol => throw new NotImplementedException();

        public MetaTraderTimeBarsAdapter(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
            this.lastCandeAdded = new Subject<ICandle>();
            this.timesBarCollection = new CandleCollection();
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
                                timeBar.OpenTime,
                                timeBar.CloseTime);

            timesBarCollection.Add(candle);
            lastCandleIndex++;

            lastCandeAdded.OnNext(candle);
        }
    }
}
