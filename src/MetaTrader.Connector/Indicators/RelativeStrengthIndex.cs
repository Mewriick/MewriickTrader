using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Indicators;
using System;

namespace MetaTrader.Connector.Indicators
{
    public class RelativeStrengthIndex : ITechnicalIndicator<RSIIndicatorParams, decimal>
    {
        public RelativeStrengthIndex()
        {

        }

        public decimal CalculateIndicatorValue(RSIIndicatorParams indicatorParameters)
        {
            throw new NotImplementedException();
        }
    }
}
