using MewriickTrader.Core.Trading.Events;
using System;

namespace MewriickTrader.Core.Trading
{
    public interface IMarketListener
    {
        event EventHandler<LastCandleEventArgs> OnLastCandle;
    }
}
