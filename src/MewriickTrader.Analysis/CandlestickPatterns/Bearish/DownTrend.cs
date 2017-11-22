using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;
using System;

namespace MewriickTrader.Analysis.CandlestickPatterns.Bearish
{
    public class DownTrend : ICandlePatternable
    {
        public int Period { get; }

        public DownTrend(int period = 3)
        {
            Period = period;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            if (Period > analyzableContext.Candles.Count)
            {
                throw new ArgumentException($"Number of candels muset be greater than {nameof(Period)}");
            }

            if (analyzableContext.CandleIndexToAnalyze <= Period - 1)
            {
                throw new ArgumentException($"{nameof(analyzableContext.CandleIndexToAnalyze)} cannot be less or equal than the {nameof(Period)}");
            }

            if (analyzableContext.CandleAtIndex.IsBullish())
            {
                return CandlePatternMatch.NoMatch;
            }

            var startIndex = analyzableContext.CandleIndexToAnalyze;
            var candles = analyzableContext.Candles;

            for (int i = 0; i < Period; i++)
            {
                if (candles[startIndex - i].High > candles[startIndex - i - 1].High)
                {
                    return CandlePatternMatch.NoMatch;
                }

                if (candles[startIndex - i].Low > candles[startIndex - i - 1].Low)
                {
                    return CandlePatternMatch.NoMatch;
                }
            }

            return CandlePatternMatch.Match;
        }
    }
}
