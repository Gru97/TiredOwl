using TiredOwl.Domain;
using TiredOwl.Domain.Campaigns;

namespace TiredOwl.Application;
public class CreateCampaignCommandHandler : ICommandHandler<CreateCampaignCommand>
{
    private ICampaignRepository _repo;

    public CreateCampaignCommandHandler(ICampaignRepository repo)
    {
        _repo = repo;
    }

    public Task Handle(CreateCampaignCommand command)
    {
        if (_repo.GetAllActiveCampaigns(GetBusinessOwnerId()).Any())
            throw new BusinessException("Another campaign is running!");

        var budget = Money.Create(command.Budget, MoneyUnit.Dollar);
        var campaignContent = new CampaignContent(command.Content, new CampaignImage(command.Image), command.Title, command.Tags);
        var campaign = Campaign.Create(budget, campaignContent, CostOption.Get(command.CostOption),
            CampaignTimingStrategy.Create(command.StartTime, command.EndTime));

        _repo.Add(campaign);
        //save to db
        return Task.CompletedTask;
    }

    private Guid GetBusinessOwnerId()
    {
        throw new NotImplementedException();
    }
}