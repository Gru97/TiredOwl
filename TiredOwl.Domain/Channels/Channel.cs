using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiredOwl.Domain.Channels;
public class Channel : Entity<Guid>, IAggregateRoot
{
    public string Name { get; private set; }
    public Guid OwnerId { get; private set; }
    public Offer Offer { get; private set; }
    public Money Credit { get; private set; }
    public Channel(string name, Guid ownerId)
    {
        Name = name;
        OwnerId = ownerId;
        Credit= Money.Default(MoneyUnit.Dollar); //?
    }

    public void AddOffer(Offer offer)
    {
        Offer = offer;
    }

    public void IncreaseCredit(Money cost)
    {
        Credit= Credit.Increase(cost);
    }
}