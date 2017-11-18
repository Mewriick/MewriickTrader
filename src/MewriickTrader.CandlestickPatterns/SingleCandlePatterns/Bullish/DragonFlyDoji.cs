using MewriickTrader.CandlestickPatterns.SingleCandlePatterns.Neutral;
using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.SingleCandlePatterns.Bullish
{
    public class DragonFlyDoji : SingleCandlePatternBase
    {
        private Doji dojiPattern;
        private decimal shadowTreshold;

        public DragonFlyDoji(Doji dojiPattern, decimal shadowTreshold = 1.0m)
        {
            this.dojiPattern = dojiPattern;
            this.shadowTreshold = shadowTreshold;
        }

        public override CandlePatternMatch Match(ICandle candle)
        {
            if (candle.Type == CandleType.Bear)
            {
                return CandlePatternMatch.NoMatch;
            }

            var isDoji = dojiPattern.Match(candle);
            var isDragonFlyDoji = isDoji.Success && candle.High - candle.MeanOpenClose() < shadowTreshold * candle.SizeFromHighToLow();

            return new CandlePatternMatch(isDragonFlyDoji);
        }
    }
}
