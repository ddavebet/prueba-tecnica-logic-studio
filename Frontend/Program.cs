using Blazored.LocalStorage;
using Frontend;
using Frontend.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new Uri("https://backend20241101012037.azurewebsites.net/api/") }
);

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TareaService>();

await builder.Build().RunAsync();
