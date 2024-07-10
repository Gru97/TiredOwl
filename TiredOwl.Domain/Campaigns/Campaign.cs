using System.Reflection.Metadata;

namespace TiredOwl.Domain.Campaigns;

public class Campaign : Entity<Guid>, IAggregateRoot
{
    private List<Topic> _topics = new();
    public IReadOnlyList<Topic> Topics => _topics;
    public Money MaximumBudget { get; private set; }
    public Money RemainingBudget { get; private set; }
    public CampaignContent Content { get; private set; }
    public CostOption CostOption { get; private set; }
    public LimitlessCampaignStrategy CampaignStrategy { get; private set; }
    public Campaign(Money maximumBudget, CampaignContent content, CostOption costOption, LimitlessCampaignStrategy campaignStrategy)
    {
        MaximumBudget = maximumBudget;
        Content = content;
        CostOption = costOption;
        CampaignStrategy = campaignStrategy;
        RemainingBudget= maximumBudget;
    }

    public static Campaign Create(Money budget, CampaignContent content, CostOption costOptions, LimitlessCampaignStrategy strategy)
    {
        return new Campaign(budget, content, costOptions, strategy);
    }

    public Campaign WithTopic(Topic topic)
    {
        if (!_topics.Contains(topic))
            _topics.Add(topic);
        return this;
    }

    public bool IsRunning(DateTime now)
    {
        if (!HasBudget() || CampaignStrategy.GetEndTime() > now)
            return false;
        return true;
    }

    private bool HasBudget() => RemainingBudget.Value > 0;
    public void DecreaseBudget(Money cost)
    {
        if (!RemainingBudget.CanDecrease(cost))
            throw new BusinessException("Not enough budget!");
        RemainingBudget= RemainingBudget.Decrease(cost);
    }
}