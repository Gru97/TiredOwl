namespace TiredOwl.Application;

public class CreateCampaignCommand
{
    public string Content { get; set; }
    public string Title { get; set; }
    public List<string> Tags { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public byte[] Image{ get; set; }
    public int CostOption{ get; set; }
    public long Budget{ get; set; }
    public List<int> Topics { get; set; }
}
