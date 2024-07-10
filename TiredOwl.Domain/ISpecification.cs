namespace TiredOwl.Domain;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}