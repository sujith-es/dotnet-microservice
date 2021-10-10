namespace PlatformServie.AsyncDataServices
{
    using PlatformService.Dtos;

    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishedDto platformPublishedDto);
    }
}