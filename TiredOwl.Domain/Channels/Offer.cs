namespace TiredOwl.Domain.Channels;

public class Offer : Entity<Guid>
{
    public TimeRange TimeRange { get; private set; }
    public Guid ChannelId { get; private set; }
    public IReadOnlyList<Topic> Topics => _topics;
    public List<Topic> _topics = new();

    public IReadOnlyList<CostStrategy> CostStrategies => _costStrategies;
    public List<CostStrategy> _costStrategies = new();

    private Offer(Guid channelId)
    {
        ChannelId = channelId;
    }

    public static Offer Create(Guid channelId)
    {
        return new Offer(channelId);
    }

    public Offer WithTopic(Topic topic)
    {
        _topics.Add(topic);
        return this;
    }

    public Offer WithCostStrategy(CostStrategy costStrategy)
    {
        _costStrategies.Add(costStrategy);
        return this;

    }

    public Offer WithCampaignHours(TimeRange timeRange)
    {
        TimeRange = timeRange;
        return this;
    }


}