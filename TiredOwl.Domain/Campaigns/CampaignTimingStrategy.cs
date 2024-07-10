namespace TiredOwl.Domain.Campaigns;

public abstract class CampaignTimingStrategy : ValueObject
{
    public DateTime? StartTime { get; }
    public DateTime? EndTime { get; }
    public abstract DateTime? GetStartTime();
    public abstract DateTime? GetEndTime();
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException(); //TODO?
    }

    public static LimitlessCampaignStrategy Create(DateTime? commandStartTime, DateTime? commandEndTime)
    {
        if (commandStartTime == default && commandEndTime == default) return new LimitlessCampaignStrategy();
        return default; // TODO: other strategies
    }
}
public class LimitlessCampaignStrategy : CampaignTimingStrategy
{
    public override DateTime? GetStartTime() => null;
    public override DateTime? GetEndTime() => null;
}