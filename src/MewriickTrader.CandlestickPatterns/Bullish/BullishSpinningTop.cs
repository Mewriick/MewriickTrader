using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.Bullish
{
    public class BullishSpinningTop : ICandlePatternable
    {
        private const int RealBodyMultiplier = 3;

        public decimal Treshold { get; }

        public BullishSpinningTop(decimal treshold = 0.001m)
        {
            Treshold = treshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.Candles[analyzableContext.CandleIndexToAnalyze];
            if (candle.IsBearish())
            {
                return CandlePatternMatch.NoMatch;
            }

            var sizeFromHighToLow = candle.SizeFromHighToLow();
            var isSpinningTop = sizeFromHighToLow > RealBodyMultiplier * candle.RealBody() &&
                                    (candle.High - candle.Open) / (Treshold + sizeFromHighToLow) < 0.4m &&
                                    (candle.Close - candle.Low) / (Treshold + sizeFromHighToLow) < 0.4m;

            return new CandlePatternMatch(isSpinningTop);
        }
    }
}
