using Discovered.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Discovered
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryAndServices(this IServiceCollection services, IConfiguration Configuration)
        {
           // string key = ;

            //services.AddScoped(sp => new HttpClient
            //{
            //    BaseAddress = new Uri(Configuration["TreasureUrl:Uri"])
            //});
        }

        public static TreasureUrl GetConfiguration()
        {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json"))
            using (var reader = new System.IO.StreamReader(stream))
            {
                return System.Text.Json.JsonSerializer.Deserialize<TreasureUrl>(reader.ReadToEnd());
            }
        }
    }
}
