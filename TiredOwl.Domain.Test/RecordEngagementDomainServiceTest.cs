using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
using TiredOwl.Domain.Campaigns;
using TiredOwl.Domain.Channels;
using Xunit;

namespace TiredOwl.Domain.Test;
public class RecordEngagementDomainServiceTest
{
    [Fact]
    public void Should_Derease_Campaign_Budget_And_Increase_Channel_Credit_In_A_Campaign_Engagement()
    {
        var campaign = CreateCampaign(CostOption.PerView, Money.Create(100, MoneyUnit.Dollar));
        var offer = CreateOffer(new PerViewStrategy(Money.Create(20, MoneyUnit.Dollar)));
        var channel = new Channel("my channel", Guid.NewGuid());
        channel.AddOffer(offer);

        var domainService = new CampaignEngagementDomainService();
        domainService.ApplyEngagement(channel, campaign);

        campaign.RemainingBudget.ShouldBe(Money.Create(80, MoneyUnit.Dollar));
        channel.Credit.ShouldBe( Money.Create(20,MoneyUnit.Dollar));
    }

    private Offer CreateOffer(CostStrategy costStrategy)
    {
        var channelId = Guid.NewGuid();
        var offer = Offer.Create(channelId)
            .WithTopic(Topic.Shopping)
            .WithTopic(Topic.Cloths)
            .WithCostStrategy(costStrategy)
            .WithCampaignHours(TimeRange.Create(8, 12));

        return offer;
    }

    private Campaign CreateCampaign(CostOption costOption, Money budget )
    {
        byte[] file = Enumerable.Repeat((byte)0x20, 100).ToArray();

        var campaign = Campaign.Create(budget,
            new CampaignContent("text goes here", new CampaignImage(file)),
            costOption,
            new LimitlessCampaignStrategy()).WithTopic(Topic.Shopping).WithTopic(Topic.Cloths);

        return campaign;
    }
}
