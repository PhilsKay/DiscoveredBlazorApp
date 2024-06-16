using Discovered.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace Discovered.Repository
{
    public class DiscorveredServices : IDiscovered
    {
        private IHttpClientFactory _clientFactory;
        private readonly IConfiguration configuration;
        private HttpClient client;
        public DiscorveredServices(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            this.configuration = configuration;
            client = _clientFactory.CreateClient("discovered");
            SetHeaders();
        }
        public async Task<DiscoveredResults> GetTodayDiscovery()
        {
            //SetHeaders();
            var response = await client.GetAsync("today");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DiscoveredResults>(result);
            }

            return new DiscoveredResults()
            {
                Results = new()
                {
                    new()
                    {
                        Text = "Can't get content at this time",
                        Context = "",
                    }

                }
            };
        }
        public async Task<DiscoveredResults> GetRandomDiscovery()
        {
            //SetHeaders();
            var response = await client.GetAsync("random");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DiscoveredResults>(result);
            }

            return new DiscoveredResults()
            {
                Results = new()
                {
                    new()
                    {
                        Text = "Can't get content at this time",
                        Context = "",
                    }

                }
            };
        }
        private void SetHeaders()
        {
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", configuration.GetSection("TreasureUrl")["Key"]);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", configuration.GetSection("TreasureUrl")["Host"]);
        }
    }
}
