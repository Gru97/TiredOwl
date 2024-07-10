using Shouldly;
using TiredOwl.Domain.Channels;
using Xunit;

namespace TiredOwl.Domain.Test;

public class OfferTests
{
    [Fact]
    public void Should_Create_Offer_By_Channel_Owner()
    {
        var channelId = Guid.NewGuid();
        var offer = Offer.Create(channelId)
            .WithTopic(Topic.Shopping)
            .WithTopic(Topic.Cloths)
            .WithCostStrategy(new PerViewStrategy(Money.Create(100, MoneyUnit.Dollar)))
            .WithCostStrategy(new PerClickStrategy(Money.Create(100,MoneyUnit.Dollar)))
            .WithCampaignHours(TimeRange.Create(8, 12));

        offer.ChannelId.ShouldBe(channelId);
        offer.CostStrategies.ShouldContain(new PerViewStrategy(Money.Create(100, MoneyUnit.Dollar)));
        offer.CostStrategies.ShouldContain(new PerClickStrategy(Money.Create(100, MoneyUnit.Dollar)));
        offer.TimeRange.ShouldBe(TimeRange.Create(8, 12));
        offer.Topics.ShouldContain(Topic.Shopping);
        offer.Topics.ShouldContain(Topic.Cloths);


    }

}