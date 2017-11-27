using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.Analysis.CandlestickPatterns.Neutral
{
    public class Doji : ICandlePatternable
    {
        private decimal treshold;

        public Doji(decimal treshold = 0.1m)
        {
            this.treshold = treshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.TimeBarAtIndex;

            if (candle.Open == candle.Close)
            {
                return new CandlePatternMatch(true, false);
            }

            var isDoji = candle.RealBody() < treshold * candle.SizeFromHighToLow();

            return new CandlePatternMatch(isDoji, false);
        }
    }
}
