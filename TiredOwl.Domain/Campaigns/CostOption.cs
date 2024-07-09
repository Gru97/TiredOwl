namespace TiredOwl.Domain.Campaigns;

public class CostOption : EnumerableValueObject
{
    private CostOption(int value, string name) : base(value, name) { }
    public static CostOption PerClick = new CostOption(1, "PerClick");
    public static CostOption PerView = new CostOption(2, "PerView");
}