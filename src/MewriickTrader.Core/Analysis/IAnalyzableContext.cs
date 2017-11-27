using MewriickTrader.Core.Candle;
using System.Collections.Generic;

namespace MewriickTrader.Core.Analysis
{
    public interface IAnalyzableContext
    {
        IReadOnlyList<ICandle> TimeBars { get; }

        int TimeBarIndexToAnalyze { get; }

        ICandle TimeBarAtIndex { get; }
    }
}
