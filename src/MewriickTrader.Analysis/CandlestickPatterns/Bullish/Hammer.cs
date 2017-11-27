using MewriickTrader.Analysis.CandlestickPatterns.Bearish;
using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.Analysis.CandlestickPatterns.Bullish
{
    public class Hammer : ICandlePatternable
    {
        private const int RealBodyMultiplier = 3;
        private const decimal Treshold = 0.001m;

        private DownTrend downTrendPattern;

        public decimal LowerWickLengthRatio { get; }


        public Hammer(DownTrend downTrendPattern, decimal lowerWickLengthRatio = 0.6m)
        {
            this.downTrendPattern = downTrendPattern;
            LowerWickLengthRatio = lowerWickLengthRatio;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.TimeBarAtIndex;
            if (candle.Open == candle.Close)
            {
                return CandlePatternMatch.NoMatch;
            }

            var upTrendContext = new CandlestickContext(analyzableContext.TimeBars, analyzableContext.TimeBarIndexToAnalyze - 1);
            var isDownTrendMatch = downTrendPattern.Match(upTrendContext);

            if (!isDownTrendMatch.Success)
            {
                return CandlePatternMatch.NoMatch;
            }

            var sizeFromHighToLow = candle.SizeFromHighToLow();
            var isHammer = sizeFromHighToLow > RealBodyMultiplier * candle.RealBody() &&
                            candle.LowerShadow() / (Treshold + sizeFromHighToLow) < LowerWickLengthRatio;

            return new CandlePatternMatch(isHammer, true);
        }
    }
}
