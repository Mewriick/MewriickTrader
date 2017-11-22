using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.Analysis.CandlestickPatterns.SingleCandlePatterns.Bearish
{
    /// <summary>
    /// Formula is taken from book Candlestick Patterns With Formula page 11
    /// </summary>
    public class BearishSpiningTop : ICandlePatternable
    {
        private const int RealBodyMultiplier = 3;

        public decimal Treshold { get; }

        public BearishSpiningTop(decimal treshold = 0.001m)
        {
            Treshold = treshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.CandleAtIndex;
            if (candle.IsBullish())
            {
                return CandlePatternMatch.NoMatch;
            }

            var sizeFromHighToLow = candle.SizeFromHighToLow();
            var isSpinningTop = sizeFromHighToLow > RealBodyMultiplier * candle.RealBody() &&
                                    (candle.High - candle.Open) / (Treshold + sizeFromHighToLow) < 0.4m &&
                                    (candle.Close - candle.Low) / (Treshold + sizeFromHighToLow) < 0.4m;

            return new CandlePatternMatch(isSpinningTop, false);
        }
    }
}
