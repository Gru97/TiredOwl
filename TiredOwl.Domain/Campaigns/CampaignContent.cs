namespace TiredOwl.Domain.Campaigns;

public class CampaignContent
{
    public string Content { get; set; }
    public List<string> Tags { get; set; }
    public string Title { get; set; }
    public CampaignContent(string content, string? title = default, List<string>? tags = default)
    {
        Content = content;
        Title = title;
        Tags = tags;
    }
}