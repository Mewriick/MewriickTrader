using MewriickTrader.Core.Analysis.Indicators;
using MtApi;

namespace MetaTrader.Connector.Indicators
{
    public class MovingAverage : BaseTechnicalIndicator<MovingAverageParams, decimal>
    {
        public MovingAverage(MtApiClient metaTraderProvider)
            : base(metaTraderProvider)
        {
        }

        protected override decimal CalculateValue(MovingAverageParams indicatorParameters)
        {
            var maValue = metaTraderProvider.iMA(indicatorParameters.Symbol,
                                    indicatorParameters.TimeFrameType,
                                    indicatorParameters.Period,
                                    indicatorParameters.MovingAvereageShift,
                                    indicatorParameters.AvereageMethodType,
                                    indicatorParameters.AppliedPriceType,
                                    indicatorParameters.Shift);

            return (decimal)maValue;
        }
    }
}
