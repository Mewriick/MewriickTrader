using MewriickTrader.Core.Trading.Market;
using System;

namespace MewriickTrader.Core.Trading.Strategy
{
    public interface ITradingStrategy : IDisposable
    {
        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// Strategy enter/exit/filtering rules
        /// </summary>
        void OnTimeBarUpdate(IQuote quoteInfo);

        void StartListeningMarket();

        void StopListeningMarket();
    }
}
