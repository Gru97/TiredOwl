namespace TiredOwl.Domain.Campaigns;

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