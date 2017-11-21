using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.Bullish
{
    public class Hammer : ICandlePatternable
    {
        public decimal Treshold { get; }


        public Hammer(decimal treshold = 0.25m)
        {
            Treshold = treshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.Candles[analyzableContext.CandleIndexToAnalyze];

            if (candle.IsBearish() || candle.Open == candle.Close)
            {
                return CandlePatternMatch.NoMatch;
            }

            var isHammer = candle.LowerShadow() > candle.RealBody() * Treshold &&
                            candle.High - candle.MeanOpenClose() < Treshold * (candle.High - candle.Low);

            return new CandlePatternMatch(isHammer);
        }
    }
}
