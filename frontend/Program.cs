using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using dotnet_todolist_blazorwasm;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ITodoService,TodoService>(client =>{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

// builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ITodoService,TodoService>();
builder.Services.AddMudServices();

builder.Logging.SetMinimumLevel(LogLevel.None);

await builder.Build().RunAsync();
