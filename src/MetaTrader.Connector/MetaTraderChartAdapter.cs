using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading;
using MtApi;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MetaTrader.Connector
{
    public class MetaTraderChartAdapter : IMarketChart
    {
        private MtApiClient metaTraderProvider;
        private Subject<ICandle> lastCandeAdded;
        private List<ICandle> candles;
        private int lastCandleIndex;

        public IObservable<ICandle> LastCandleAdded => lastCandeAdded.AsObservable();

        public IList<ICandle> Candles => candles;

        public ICandle LastCandle => candles[lastCandleIndex];

        public string Symbol => throw new NotImplementedException();

        public MetaTraderChartAdapter(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
            this.lastCandeAdded = new Subject<ICandle>();
            this.candles = new List<ICandle>();
            this.lastCandleIndex = 0;

            this.metaTraderProvider.OnLastTimeBar += FireOnLastTimeBar;
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
