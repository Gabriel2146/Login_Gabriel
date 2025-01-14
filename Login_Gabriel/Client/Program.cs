using Login_Gabriel.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Login_Gabriel.Client.Extensiones;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationExtension>();
builder.Services.AddAuthorizationCore();



await builder.Build().RunAsync();
