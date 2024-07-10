namespace TiredOwl.Domain.Channels;
public class CostStrategy : ValueObject
{
    public Money Cost { get; set; }
    public CostOption CostOption { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CostOption;
        yield return Cost;
    }
}
public class PerClickStrategy : CostStrategy
{
    public PerClickStrategy(Money cost)
    {
        CostOption = CostOption.PerClick;
        Cost = cost;
    }
}
public class PerViewStrategy : CostStrategy
{
    public PerViewStrategy(Money cost)
    {
        CostOption = CostOption.PerView;
        Cost = cost;
    }
}

