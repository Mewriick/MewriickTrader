using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;
using System;
using System.Collections.Generic;

namespace CandlePattersTests.Mocks
{
    public class TestCandlesContext : IAnalyzableContext
    {
        private List<ICandle> candles;
        private int candleIndex;

        public IReadOnlyList<ICandle> Candles { get { return candles; } }

        public int CandleIndexToAnalyze { get { return candleIndex; } }

        public ICandle CandleAtIndex => Candles[CandleIndexToAnalyze];

        public TestCandlesContext()
        {
            candleIndex = 0;
            candles = new List<ICandle>();
        }

        public TestCandlesContext WithBasicCandles()
        {
            var basicCandles = new List<ICandle>()
            {
              { new Candle(1.17955m, 1.17959m, 1.17939m, 1.17957m, DateTime.Now) }, // Hammer
              { new Candle(1.17943m, 1.17946m, 1.17934m, 1.17946m, DateTime.Now) }, // Hammer
              { new Candle(1.17937m, 1.17942m, 1.17932m, 1.17937m, DateTime.Now) }, // Doji
              { new Candle(1.17917m, 1.17924m, 1.17911m, 1.17918m, DateTime.Now) }, // Doji
              { new Candle(1.17972m, 1.17973m, 1.17964m, 1.17972m, DateTime.Now) }, // BullishDragonFlyDoji
              { new Candle(1.17947m, 1.17947m, 1.17945m, 1.17947m, DateTime.Now) }, // BullishDragonFlyDoji
              { new Candle(1.17943m, 1.17944m, 1.17938m, 1.17943m, DateTime.Now) }, // BullishDragonFlyDoji
              { new Candle(1.17923m, 1.17926m, 1.17910m, 1.17924m, DateTime.Now) }, // BullishDragonFlyDoji
              { new Candle(1.17922m, 1.17925m, 1.17917m, 1.17921m, DateTime.Now) }, // BearishSpinningTop
              { new Candle(1.17918m, 1.17924m, 1.17912m, 1.17919m, DateTime.Now) }, // BullishSpinningTop
              { new Candle(1.17933m, 1.17941m, 1.17927m, 1.17934m, DateTime.Now) }, // BullishSpinningTop
            };

            candles.AddRange(basicCandles);

            return this;
        }

        public TestCandlesContext WithUpTrend()
        {
            var upTrendCandles = new List<ICandle>()
            {
              { new Candle(1.17900m, 1.17907m, 1.17899m, 1.17906m, DateTime.Now) },
              { new Candle(1.17905m, 1.17915m, 1.17905m, 1.17910m, DateTime.Now) },
              { new Candle(1.17911m, 1.17920m, 1.17910m, 1.17912m, DateTime.Now) },
              { new Candle(1.17912m, 1.17921m, 1.17912m, 1.17913m, DateTime.Now) },
            };

            candles.AddRange(upTrendCandles);

            return this;
        }

        public TestCandlesContext WithDownTrend()
        {
            var downTrendCandles = new List<ICandle>()
            {
              { new Candle(1.17954m, 1.17956m, 1.17947m, 1.17948m, DateTime.Now) },
              { new Candle(1.17950m, 1.17953m, 1.17946m, 1.17947m, DateTime.Now) },
              { new Candle(1.17946m, 1.17947m, 1.17941m, 1.17942m, DateTime.Now) },
              { new Candle(1.17943m, 1.17944m, 1.17826m, 1.17927m, DateTime.Now) },
            };

            candles.AddRange(downTrendCandles);

            return this;
        }

        public TestCandlesContext WithHammers()
        {
            var hammerCandles = new List<ICandle>()
            {
              { new Candle(1.17954m, 1.17956m, 1.17947m, 1.17948m, DateTime.Now) },
              { new Candle(1.17950m, 1.17953m, 1.17946m, 1.17947m, DateTime.Now) },
              { new Candle(1.17946m, 1.17947m, 1.17941m, 1.17942m, DateTime.Now) },
              { new Candle(1.17943m, 1.17944m, 1.17826m, 1.17927m, DateTime.Now) },
              { new Candle(1.17913m, 1.17915m, 1.17901m, 1.17915m, DateTime.Now) }, // Hammer
              { new Candle(1.17954m, 1.17956m, 1.17947m, 1.17948m, DateTime.Now) },
              { new Candle(1.17950m, 1.17953m, 1.17946m, 1.17947m, DateTime.Now) },
              { new Candle(1.17946m, 1.17947m, 1.17941m, 1.17942m, DateTime.Now) },
              { new Candle(1.17943m, 1.17944m, 1.17826m, 1.17927m, DateTime.Now) },
              { new Candle(1.17943m, 1.17946m, 1.17934m, 1.17946m, DateTime.Now) }, // Hammer
            };

            candles.AddRange(hammerCandles);

            return this;
        }

        public TestCandlesContext WithBullishDragonFlyDoji()
        {
            var dojiCandle = new List<ICandle>()
            {
                { new Candle(1.17972m, 1.17973m, 1.17964m, 1.17972m, DateTime.Now) },
            };

            candles.AddRange(dojiCandle);

            return this;
        }

        public TestCandlesContext WithBigBullishCandle()
        {
            var bigCandle = new List<ICandle>()
            {
                { new Candle(1.17191m, 1.17246m, 1.17189m, 1.17242m, DateTime.Now) },
            };

            candles.AddRange(bigCandle);

            return this;
        }

        public TestCandlesContext WithPinBar()
        {
            var pinBar = new List<ICandle>()
            {
                { new Candle(1.17913m, 1.17915m, 1.17901m, 1.17915m, DateTime.Now) },
            };

            candles.AddRange(pinBar);

            return this;
        }

        public TestCandlesContext WithCandleIndex(int candleIndex)
        {
            this.candleIndex = candleIndex;

            return this;
        }
    }
}
