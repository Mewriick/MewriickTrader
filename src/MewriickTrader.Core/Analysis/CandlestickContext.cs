using MewriickTrader.Core.Candle;
using System;
using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis
{
    public class CandlestickContext : IAnalyzableContext
    {
        public IReadOnlyList<ICandle> Candles { get; }

        public int CandleIndexToAnalyze { get; }

        public ICandle CandleAtIndex => Candles[CandleIndexToAnalyze];

        public CandlestickContext(IReadOnlyList<ICandle> candles, int candleIndex)
        {
            Candles = candles ?? throw new ArgumentNullException(nameof(candles));

            if (Candles.Count < candleIndex)
            {
                throw new ArgumentException($"{nameof(candleIndex)} must be between 0 and {Candles.Count}");
            }

            CandleIndexToAnalyze = candleIndex;
        }
    }
}
