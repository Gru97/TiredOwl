namespace TiredOwl.Domain.ChannelOwners;

public class ChannelOwner : Entity<Guid>, IAggregateRoot
{
    public string Name { get; private set; }
    public BankAccount BankAccount { get; private set; }
    public Phone Phone { get; set; }
    public IReadOnlyList<Guid> ChannelIds => _channelId;
    private List<Guid> _channelId = new ();

    public void AddChannel(Guid id)
    {
        if (_channelId.Count >= 5)
            throw new BusinessException("More than 5 channels are not allowed!");
    }
}

public class Phone : ValueObject
{
    public string Number { get; set; }
    public string Code { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
        yield return Code;
    }
}