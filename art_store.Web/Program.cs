using art_store.Services.Contract;
using art_store.Web;
using art_store.Web.Requests;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7127")
});
builder.Services.AddScoped<ArtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, ArtAuthenticationStateProvider>();
builder.Services.AddScoped<IArtService, ApiArtService>();
builder.Services.AddScoped<IUserService, ApiUserService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddMudServices(); 
await builder.Build().RunAsync();
