namespace TiredOwl.Application;

public class RecordEngagementCommand
{
    public DateTime EngagementTime { get; set; }
    public Guid CampaignId { get; set; }
    public Guid ChannelId { get; set; }
}