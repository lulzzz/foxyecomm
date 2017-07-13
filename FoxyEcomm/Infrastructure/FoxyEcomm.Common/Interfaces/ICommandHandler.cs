namespace FoxyEcomm.Common.Interfaces
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<TCommand> : IHandler<TCommand>, ICommandHandler
        where TCommand : class, ICommand
    {
    }
}
