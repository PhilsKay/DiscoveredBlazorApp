using Discovered.Models;
using System.Net.Http.Json;

namespace Discovered.Repository
{
    public class BibleService : IBibleApi
    {
        private IHttpClientFactory _clientFactory;
        private HttpClient client;
        public BibleService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("bible");

        }
        public async Task<BibleData> GetScriptures(string verse,string version)
        {
            return await client.GetFromJsonAsync<BibleData>($"{verse}?translation={version}");
        }
    }
}
