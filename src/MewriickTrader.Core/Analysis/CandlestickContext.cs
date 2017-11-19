using MewriickTrader.Core.Candle;
using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis
{
    public class CandlestickContext : IAnalyzableContext
    {
        public IReadOnlyList<ICandle> Candles { get; }

        public int CandleIndexToAnalyze { get; }

        public CandlestickContext(IReadOnlyList<ICandle> candles, int candleIndex)
        {
            Candles = candles;
            CandleIndexToAnalyze = candleIndex;
        }
    }
}
