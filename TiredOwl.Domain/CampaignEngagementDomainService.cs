using TiredOwl.Domain.Campaigns;
using TiredOwl.Domain.Channels;

namespace TiredOwl.Domain;

public class CampaignEngagementDomainService
{
    public void ApplyEngagement(Channel channel, Campaign campaign)
    {
        var costStrategy = channel.Offer.CostStrategies.First(e => e.CostOption == campaign.CostOption);
        campaign.DecreaseBudget(costStrategy.Cost);
        channel.IncreaseCredit(costStrategy.Cost);
    }
}