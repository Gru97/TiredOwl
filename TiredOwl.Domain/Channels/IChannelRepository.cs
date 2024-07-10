namespace TiredOwl.Domain.Channels;

public interface IChannelRepository
{
    Channel Get(Guid commandChannelId);
    void Update(Channel channel);
}