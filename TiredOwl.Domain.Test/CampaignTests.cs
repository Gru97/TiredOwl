using Shouldly;
using TiredOwl.Domain.Campaigns;
using Xunit;

namespace TiredOwl.Domain.Test;

public class CampaignTests
{
    [Fact]
    public void Should_Create_Campaign()
    {
        byte[] file = Enumerable.Repeat((byte)0x20, 100).ToArray();

        var campaign = Campaign.Create(Money.Create(100,MoneyUnit.Dollar),
             new CampaignContent("text goes here", new CampaignImage(file)), 
            CostOption.PerClick, 
            new LimitlessCampaignStrategy()).WithTopic(Topic.Shopping).WithTopic(Topic.Cloths);
        

        campaign.Topics.ShouldContain(Topic.Shopping);
        campaign.CostOption.ShouldBe(CostOption.PerClick);
        campaign.CampaignStrategy.ShouldBeOfType(typeof(LimitlessCampaignStrategy));
        //campaign.Content.ShouldBe(new CampaignContent("text goes here"));  //TODO?
        campaign.MaximumBudget.ShouldBe(Money.Create(100, MoneyUnit.Dollar));
    }
    [Fact]
    public void Should_Decrease_Budget()
    {
        byte[] file = Enumerable.Repeat((byte)0x20, 100).ToArray();

        var campaign = Campaign.Create(Money.Create(100, MoneyUnit.Dollar),
            new CampaignContent("text goes here", new CampaignImage(file)),
            CostOption.PerClick,
            new LimitlessCampaignStrategy()).WithTopic(Topic.Shopping).WithTopic(Topic.Cloths);

        campaign.DecreaseBudget(Money.Create(10,MoneyUnit.Dollar));
        campaign.RemainingBudget.ShouldBe(Money.Create(90, MoneyUnit.Dollar));
        
    }


}