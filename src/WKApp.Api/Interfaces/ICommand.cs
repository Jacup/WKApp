namespace WKApp.Api.Interfaces
{
    public interface ICommandHandler<T, TCommand>
    {
        T Handle(TCommand command);
    }
}