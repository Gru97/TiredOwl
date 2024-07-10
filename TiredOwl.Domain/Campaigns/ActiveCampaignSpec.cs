namespace TiredOwl.Domain.Campaigns;

public class ActiveCampaignSpec : ISpecification<Campaign> //usage in implementation of CampaignRepository
{
    private readonly DateTime _now;

    public ActiveCampaignSpec(DateTime now)
    {
        _now = now;
    }
    public bool IsSatisfiedBy(Campaign campaign) => campaign.IsRunning(_now);
    
}