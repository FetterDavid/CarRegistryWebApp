using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7166") });
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarOwnershipService, CarOwnershipService>();

await builder.Build().RunAsync();
