namespace TiredOwl.Domain.Campaigns;

public class CampaignContent
{
    public string Content { get; set; }
    public List<string> Tags { get; set; }
    public string? Title { get; set; }
    public CampaignImage Image { get; private set; }

    public CampaignContent(string content, CampaignImage image, string? title = default, List<string>? tags = default)
    {
        if (content.Length > 100)
            throw new BusinessException("Content can't be more than 100 characters.");
        Content = content;
        Title = title;
        Tags = tags?? new List<string>();
        Image = image;
    }
}