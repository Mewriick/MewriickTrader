using MewriickTrader.Core.Candle;
using MewriickTrader.Core.Trading.Market;
using System;

namespace MewriickTrader.Core.Trading.Strategy
{
    public interface ITradingStrategy : IDisposable
    {
        /// <summary>
        /// Called on each bar update event (incoming tick)
        /// Strategy exit rules (for quickier possibility to react)
        /// </summary>
        void OnTimeBarUpdate(IQuote quote);

        /// <summary>
        /// Called when time bar is closed
        /// Strategy enter/exit/filtering rules
        /// </summary>
        void OnTimeBarClosed(ICandle timeBar);

        void StartListeningMarket();

        void StopListeningMarket();
    }
}
