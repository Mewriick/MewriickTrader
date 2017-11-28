namespace MewriickTrader.Core.Analysis
{
    public interface ITechnicalIndicator<in TIput, out TOutput>
    {
        TOutput CalculateIndicatorValue(TIput indicatorParameters);
    }
}
