using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.Bullish
{
    public class InvertedHammer : ICandlePatternable
    {
        public decimal Treshold { get; }

        public InvertedHammer(decimal treshold = 0.25m)
        {
            Treshold = treshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.Candles[analyzableContext.CandleIndexToAnalyze];
            if (candle.Type == CandleType.Bearish)
            {
                return CandlePatternMatch.NoMatch;
            }

            var isInvertedHammer = candle.UpperShadow() > candle.RealBody() * Treshold &&
               candle.MeanOpenClose() - candle.Low < Treshold * (candle.High - candle.Low);

            return new CandlePatternMatch(isInvertedHammer);
        }
    }
}
