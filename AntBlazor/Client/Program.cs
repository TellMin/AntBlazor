using AntBlazor.Client;
using AntBlazor.Client.Handler;
using AntBlazor.Client.Interfaces.Services;
using AntBlazor.Client.Providers;
using AntBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("API", client => { client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); })
    .ConfigurePrimaryHttpMessageHandler<AddXMLHttpRequestHandler>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<HttpClientProvider>();

builder.Services.AddTransient<AddXMLHttpRequestHandler>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();


builder.Services.AddAntDesign();

await builder.Build().RunAsync();
