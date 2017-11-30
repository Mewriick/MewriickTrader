using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.MetaTrader;
using MtApi;
using System;

namespace MetaTrader.Connector.Indicators
{
    public abstract class BaseTechnicalIndicator<TInput, TOutput> : ITechnicalIndicator<TInput, TOutput>
    {
        protected MtApiClient metaTraderProvider;

        public BaseTechnicalIndicator(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
        }

        public TOutput CalculateIndicatorValue(TInput indicatorParameters)
        {
            if (!metaTraderProvider.IsConnected())
            {
                throw new MetaTraderNotConnectedException("There is no connection to the MetaTrader");
            }

            return CalculateValue(indicatorParameters);
        }

        protected abstract TOutput CalculateValue(TInput indicatorParameters);
    }
}
