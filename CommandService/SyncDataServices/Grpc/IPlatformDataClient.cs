namespace CommandService.SyncDataServices.Grpc
{
    using CommandService.Models;
    using System.Collections.Generic;

    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}
