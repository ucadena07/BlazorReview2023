using BlazorWasmReview.Business;
using BlazorWasmReview.Client;
using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.DataAccess;
using BlazorWasmReview.GeneralUI.BusyOverlay;
using BlazorWasmReview.IndexDb;
using BlazorWasmReview.InMemoryStorage;
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
builder.Services.AddScoped<IItemDataAccess, ItemDataAccess>();
builder.Services.AddScoped<IPersistenceService, IndexedDB>();
builder.Services.AddScoped<ItemEditService>();
builder.Services.AddScoped<InProgressOverlayService>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorWasmReview.ServerAPI"));

var host = builder.Build();

var persistenceService = host.Services.GetRequiredService<IPersistenceService>();
await persistenceService.InitAsync();

var currentUserService = host.Services.GetRequiredService<ICurrentUserService>();
var userItemManager = host.Services.GetRequiredService<IUserItemManager>();
var userManager = host.Services.GetRequiredService<IUserManager>();

if (persistenceService is InMemoryStorage)
{
    TestData.CreateTestUser(userItemManager, userManager);
    currentUserService.CurrentUser = TestData.TestUser;
}



await host.RunAsync();
