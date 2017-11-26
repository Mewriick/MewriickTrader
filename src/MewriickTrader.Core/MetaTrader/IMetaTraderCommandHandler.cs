namespace MewriickTrader.Core.MetaTrader
{
    public interface IMetaTraderCommandHandler<in TInput, out TOutput>
        where TInput : class
        where TOutput : class
    {
        TOutput Excecute(TInput command);
    }
}
