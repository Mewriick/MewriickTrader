using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.SingleCandlePatterns.Bullish
{
    public class Hammer : SingleCandlePatternBase
    {
        private decimal treshold;

        public Hammer(decimal treshold = 0.25m)
        {
            this.treshold = treshold;
        }

        public override CandlePatternMatch Match(ICandle candle)
        {
            if (candle.Type == CandleType.Bear || candle.Open == candle.Close)
            {
                return CandlePatternMatch.NoMatch;
            }

            var isHammer = candle.LowerShadow() > candle.RealBody() * treshold &&
                            candle.High - candle.MeanOpenClose() < treshold * (candle.High - candle.Low);

            return new CandlePatternMatch(isHammer);
        }
    }
}
