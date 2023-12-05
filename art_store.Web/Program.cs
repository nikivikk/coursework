using art_store.Services.Contract;
using art_store.Web;
using art_store.Web.Requests;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<IArtService, ApiArtService>();
builder.Services.AddScoped<IUserService, ApiUserService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7127")
});
builder.Services.AddMudServices(); 
await builder.Build().RunAsync();
