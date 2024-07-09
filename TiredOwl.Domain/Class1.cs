namespace TiredOwl.Domain;
public class LimitlessCampaignStrategy : CampaignTimingStrategy
{
    public override DateTime? GetStartTime() => null;
    public override DateTime? GetEndTime() => null;
}
public abstract class CampaignTimingStrategy : ValueObject
{
    public DateTime? StartTime { get; }
    public DateTime? EndTime { get; }
    public abstract DateTime? GetStartTime();
    public abstract DateTime? GetEndTime();
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
public class CostOption : EnumerableValueObject
{
    private CostOption(int value, string name) : base(value, name) { }
    public static CostOption PerClick = new CostOption(1, "PerClick");
}

public class Campaign : Entity<Guid>
{
    private List<Topic> _topics = new(); 
    public IReadOnlyList<Topic> Topics => _topics;
    public Money Budget { get; private set; }
    public CampaignContent Content { get; private set; }
    public CostOption CostOption { get; private set; }
    public LimitlessCampaignStrategy CampaignStrategy { get; private set; }
    public CampaignImage Image { get; private set; }
    public Campaign(Money budget, CampaignContent content, CostOption costOption, LimitlessCampaignStrategy campaignStrategy)
    {
        Budget = budget;
        Content = content;
        CostOption = costOption;
        CampaignStrategy = campaignStrategy;
    }

    public void UploadImage(byte[] imgAsByte)
    {
        Image = new CampaignImage(imgAsByte);
    }

    public static Campaign Create(Money budget, CampaignContent content, CostOption costOptions, LimitlessCampaignStrategy strategy)
    {
        return new Campaign(budget, content, costOptions, strategy);
    }

    public Campaign WithTopic(Topic topic)
    {
        _topics.Add(topic);
        return this;
    }
}

public class CampaignContent
{
    public string Content { get; set; }
    public List<string> Tags { get; set; }
    public string Title { get; set; }
    public CampaignContent(string content, string? title = default, List<string>? tags = default)
    {
        Content = content;
        Title = title;
        Tags = tags;
    }
}

public class CampaignImage
{
    public byte[] File { get; set; }
    public CampaignImage(byte[] file)
    {
        File = file;
    }
}

public class Topic : EnumerableValueObject
{
    public Topic(int value, string name) : base(value, name) { }
    public static Topic Shopping = new Topic(1, "Shopping");
    public static Topic Cloths = new Topic(2, "Cloths");
}

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
