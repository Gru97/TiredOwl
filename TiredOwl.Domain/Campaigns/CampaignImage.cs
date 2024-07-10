namespace TiredOwl.Domain.Campaigns;

public class CampaignImage
{
    public byte[] File { get; set; }
    public CampaignImage(byte[] file)
    {
        //checking file type, size etc.
        File = file;
    }
}