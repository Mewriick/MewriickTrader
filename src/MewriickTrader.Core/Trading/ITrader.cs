using System;

namespace MewriickTrader.Core.Trading
{
    public interface ITrader : IDisposable
    {
        void StartTrading();

        void StopTrading();
    }
}
