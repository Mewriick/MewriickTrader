using MewriickTrader.Core.Candle;
using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis
{
    public interface IAnalyzableContext
    {
        IReadOnlyList<ICandle> Candles { get; }

        int CandleIndexToAnalyze { get; }

        ICandle CandleAtIndex { get; }
    }
}
