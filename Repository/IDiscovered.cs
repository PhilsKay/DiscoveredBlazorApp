using Discovered.Models;

namespace Discovered.Repository
{
    public interface IDiscovered
    {
        Task<DiscoveredResults> GetTodayDiscovery();
        Task<DiscoveredResults> GetRandomDiscovery();
    }
}
