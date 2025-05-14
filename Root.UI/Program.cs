using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Root.UI;
using Root.UI.Services;
using Root.UI.Services.APIServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

CultureInfo culture = new("pt-AO");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44330/") });
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PackageService>();
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<GuideService>();
builder.Services.AddScoped<AdministratorService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ReserveService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<LocalStorageService>();

await builder.Build().RunAsync();