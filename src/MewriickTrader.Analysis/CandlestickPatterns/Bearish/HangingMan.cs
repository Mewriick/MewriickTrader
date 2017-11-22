using MewriickTrader.Analysis.CandlestickPatterns.Bullish;
using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.Analysis.CandlestickPatterns.Bearish
{
    public class HangingMan : ICandlePatternable
    {
        private const int RealBodyMultiplier = 3;
        private const decimal Treshold = 0.001m;

        private UpTrend upTrendPatter;

        public decimal LowerWickLengthRatio { get; }


        public HangingMan(UpTrend upTrendPatter, decimal lowerWickLengthRatio = 0.6m)
        {
            this.upTrendPatter = upTrendPatter;
            LowerWickLengthRatio = lowerWickLengthRatio;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.CandleAtIndex;
            if (candle.Open == candle.Close)
            {
                return CandlePatternMatch.NoMatch;
            }

            var upTrendContext = new CandlestickContext(analyzableContext.Candles, analyzableContext.CandleIndexToAnalyze - 1);
            var isUptrendMatch = upTrendPatter.Match(upTrendContext);

            if (!isUptrendMatch.Success)
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
