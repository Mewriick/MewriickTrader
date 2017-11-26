using MewriickTrader.Core.MetaTrader;
using MtApi;
using System;

namespace MetaTrader.Connector.CommandHandlers
{
    public abstract class BaseCommandHandler<TInput, TOutput> : IMetaTraderCommandHandler<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {

        protected MtApiClient metaTraderProvider;

        public BaseCommandHandler(MtApiClient metaTraderProvider)
        {
            this.metaTraderProvider = metaTraderProvider ?? throw new ArgumentNullException(nameof(metaTraderProvider));
        }

        public TOutput Excecute(TInput command)
        {
            if (!metaTraderProvider.IsConnected())
            {
                throw new MetaTraderNotConnectedException("There is no connection to the MetaTrader");
            }

            return ExcecuteCommand(command);
        }

        protected abstract TOutput ExcecuteCommand(TInput command);
    }
}
