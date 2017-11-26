using System;

namespace MewriickTrader.Core.MetaTrader
{
    public class MetaTraderNotConnectedException : Exception
    {
        public MetaTraderNotConnectedException(string message)
            : base(message)
        {
        }
    }
}
