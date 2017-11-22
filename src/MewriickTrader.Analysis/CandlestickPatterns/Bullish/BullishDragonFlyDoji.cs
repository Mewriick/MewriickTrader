using MewriickTrader.Analysis.CandlestickPatterns.Neutral;
using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.Analysis.CandlestickPatterns.Bullish
{
    /// <summary>
    /// Formula is taken from book Candlestick Patterns With Formula page 10
    /// </summary>
    public class BullishDragonFlyDoji : ICandlePatternable
    {
        private Doji dojiPattern;

        public decimal ShadowTreshold;

        public BullishDragonFlyDoji(Doji dojiPattern, decimal shadowTreshold = 0.8m)
        {
            this.dojiPattern = dojiPattern;
            ShadowTreshold = shadowTreshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.CandleAtIndex;

            var isDoji = dojiPattern.Match(analyzableContext);
            var sizeHighToLow = candle.SizeFromHighToLow();

            var isDragonFlyDoji = isDoji.Success &&
                                  sizeHighToLow > 3 * candle.RealBody() &&
                                  candle.Close - candle.Low > ShadowTreshold * sizeHighToLow &&
                                  candle.Open - candle.Low > ShadowTreshold * sizeHighToLow;

            return new CandlePatternMatch(isDragonFlyDoji);
        }
    }
}
