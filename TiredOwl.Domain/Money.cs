namespace TiredOwl.Domain;

public class Money : ValueObject
{
    public long Value { get; }
    public MoneyUnit Unit { get; }

    public static Money Create(long value, MoneyUnit unit) => new Money(value, unit);

    private Money(long value, MoneyUnit unit)
    {
        if (value < 0) throw new BusinessException("Wrong value for money!");
        Value = value;
        Unit = unit;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Unit;
    }

    public Money Decrease(Money cost) => Create(Value - cost.Value, cost.Unit); //possible unit conversions

    public bool CanDecrease(Money cost) => Value - cost.Value >= 0;

    public static Money Default(MoneyUnit unit) => Create(0, unit);

    public Money Increase(Money cost) => Create(Value + cost.Value, cost.Unit); //possible unit conversions
}
public enum MoneyUnit
{
    Dollar,
}
