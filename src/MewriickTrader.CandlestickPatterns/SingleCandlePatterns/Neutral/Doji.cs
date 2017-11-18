using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.SingleCandlePatterns.Neutral
{
    public class Doji : SingleCandlePatternBase
    {
        private decimal treshold;

        public Doji(decimal treshold = 0.1m)
        {
            this.treshold = treshold;
        }

        public override CandlePatternMatch Match(ICandle candle)
        {
            if (candle.Open == candle.Close)
            {
                return new CandlePatternMatch(true);
            }

            var isDoji = candle.RealBody() < treshold * candle.SizeFromHighToLow();

            return new CandlePatternMatch(isDoji);
        }
    }
}
