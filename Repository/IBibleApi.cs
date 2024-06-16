using Discovered.Models;

namespace Discovered.Repository
{
    public interface IBibleApi
    {
        Task<BibleData> GetScriptures(string verse, string version);
    }
}
