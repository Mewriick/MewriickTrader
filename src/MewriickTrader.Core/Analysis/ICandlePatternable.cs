namespace MewriickTrader.Core.Analysis
{
    public interface ICandlePatternable
    {
        CandlePatternMatch Match(IAnalyzableContext analyzableContext);
    }
}
