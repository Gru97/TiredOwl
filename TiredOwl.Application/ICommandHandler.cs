namespace TiredOwl.Application;

public interface ICommandHandler<in T> where T : class
{
    Task Handle(T command);
}