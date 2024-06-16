using Discovered;
using Discovered.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Net;
using Discovered.Repository;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




//Discorvered
builder.Services.AddHttpClient("discovered", client =>
{
    client.BaseAddress = new Uri("https://uncovered-treasure-v1.p.rapidapi.com/");
});
//Bible
//builder.Services.AddTransient(sp => new HttpClient<> { BaseAddress = new Uri("https://bible-api.com/") });
//build
builder.Services.AddHttpClient("bible", client =>
{
    client.BaseAddress = new Uri("https://bible-api.com/");
});

builder.Services.AddTransient<IDiscovered, DiscorveredServices>();
builder.Services.AddTransient<IBibleApi,BibleService>();


await builder.Build().RunAsync();
