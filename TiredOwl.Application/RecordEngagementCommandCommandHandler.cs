using TiredOwl.Domain;
using TiredOwl.Domain.Campaigns;
using TiredOwl.Domain.Channels;

namespace TiredOwl.Application;

public class RecordEngagementCommandCommandHandler : ICommandHandler<RecordEngagementCommand>
{
    private ICampaignRepository _campaignRepo;
    private IChannelRepository  _channelRepo;
    private readonly CampaignEngagementDomainService _campaignEngagementDomainService;
    public RecordEngagementCommandCommandHandler(ICampaignRepository campaignRepo, IChannelRepository channelRepo, CampaignEngagementDomainService campaignEngagementDomainService)
    {
        _campaignRepo = campaignRepo;
        _channelRepo = channelRepo;
        _campaignEngagementDomainService = campaignEngagementDomainService;
    }

    public Task Handle(RecordEngagementCommand command)
    {
        var channel= _channelRepo.Get(command.ChannelId);
        var campaign = _campaignRepo.GetById(command.CampaignId);

        _campaignEngagementDomainService.ApplyEngagement(channel, campaign);

        _campaignRepo.Update(campaign);
        _channelRepo.Update(channel);
        //save to db
        return Task.CompletedTask;
    }

    private Guid GetBusinessOwnerId()
    {
        throw new NotImplementedException();
    }
}