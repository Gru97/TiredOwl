namespace TiredOwl.Domain.Campaigns;

public class Money : ValueObject
{
    public long Value { get; }
    public MoneyUnit Unit { get; }

    public static Money Create(long value, MoneyUnit unit) => new Money(value, unit);

    private Money(long value, MoneyUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Unit;
    }
}
public enum MoneyUnit
{
    Dollar
}
