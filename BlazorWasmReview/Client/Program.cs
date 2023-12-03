using BlazorWasmReview.Business;
using BlazorWasmReview.Client;
using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.TestFake;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorWasmReview.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
///builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddSingleton<IUserManager, UserManagerFake>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IUserItemManager, UserItemManager>();
builder.Services.AddScoped<ItemEditService>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorWasmReview.ServerAPI"));

var host = builder.Build();

var currentUserService = host.Services.GetRequiredService<ICurrentUserService>();
TestData.CreateTestUser();
currentUserService.CurrentUser = TestData.TestUser;
await host.RunAsync();
