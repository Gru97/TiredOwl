using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiredOwl.Domain.Campaigns;

public interface ICampaignRepository
{
    void Add(Campaign campaign);
    List<Campaign> GetAllActiveCampaigns(Guid businessOwnerId);
    Campaign GetById(Guid id);
    void Update(Campaign campaign);
}