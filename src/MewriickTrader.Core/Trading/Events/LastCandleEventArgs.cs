using MewriickTrader.Core.Candle;
using System;

namespace MewriickTrader.Core.Trading.Events
{
    public class LastCandleEventArgs : EventArgs
    {
        public ICandle LastCandle { get; }

        public LastCandleEventArgs(ICandle lastCandle)
        {
            LastCandle = lastCandle;
        }
    }
}
