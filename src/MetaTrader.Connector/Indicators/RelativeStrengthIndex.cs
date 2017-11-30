using MewriickTrader.Core.Indicators;
using MtApi;

namespace MetaTrader.Connector.Indicators
{
    public class RelativeStrengthIndex : BaseTechnicalIndicator<RSIIndicatorParams, decimal>
    {
        public RelativeStrengthIndex(MtApiClient metaTraderProvider)
            : base(metaTraderProvider)
        {
        }

        protected override decimal CalculateValue(RSIIndicatorParams indicatorParameters)
        {
            var rsiValue = metaTraderProvider.iRSI(indicatorParameters.Symbol,
                                    indicatorParameters.TimeFrameType,
                                    indicatorParameters.Period,
                                    indicatorParameters.AppliedPriceType,
                                    indicatorParameters.Shift);

            return (decimal)rsiValue;
        }
    }
}
