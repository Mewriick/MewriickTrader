using MewriickTrader.Core.Candle;
using System;
using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis
{
    public class CandlestickContext : IAnalyzableContext
    {
        public IReadOnlyList<ICandle> TimeBars { get; }

        public int TimeBarIndexToAnalyze { get; }

        public ICandle TimeBarAtIndex => TimeBars[TimeBarIndexToAnalyze];

        public CandlestickContext(IReadOnlyList<ICandle> candles, int candleIndex)
        {
            TimeBars = candles ?? throw new ArgumentNullException(nameof(candles));

            if (TimeBars.Count < candleIndex)
            {
                throw new ArgumentException($"{nameof(candleIndex)} must be between 0 and {TimeBars.Count}");
            }

            TimeBarIndexToAnalyze = candleIndex;
        }
    }
}
