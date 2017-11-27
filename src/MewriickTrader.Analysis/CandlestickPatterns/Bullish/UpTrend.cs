using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.Analysis.CandlestickPatterns.Bullish
{
    public class UpTrend : ICandlePatternable
    {
        public int Period { get; }

        public UpTrend(int period = 3)
        {
            Period = period;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            if (Period > analyzableContext.TimeBars.Count)
            {
                return CandlePatternMatch.NoMatch;
                //throw new ArgumentException($"Number of candels muset be greater than {nameof(Period)}");
            }

            if (analyzableContext.TimeBarIndexToAnalyze <= Period - 1)
            {
                return CandlePatternMatch.NoMatch;
                //throw new ArgumentException($"{nameof(analyzableContext.CandleIndexToAnalyze)} cannot be less or equal than the {nameof(Period)}");
            }

            if (analyzableContext.TimeBarAtIndex.IsBearish())
            {
                return CandlePatternMatch.NoMatch;
            }

            var startIndex = analyzableContext.TimeBarIndexToAnalyze;
            var candles = analyzableContext.TimeBars;

            for (int i = 0; i < Period; i++)
            {
                if (candles[startIndex - i].High < candles[startIndex - i - 1].High)
                {
                    return CandlePatternMatch.NoMatch;
                }

                if (candles[startIndex - i].Low < candles[startIndex - i - 1].Low)
                {
                    return CandlePatternMatch.NoMatch;
                }
            }

            return CandlePatternMatch.MatchWithoutConfirmationNeeded;
        }
    }
}
