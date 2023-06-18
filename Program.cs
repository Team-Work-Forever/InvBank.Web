using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using InvBank.Web;
using InvBank.Web.Helper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHelper();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5099") });

await builder.Build().RunAsync();
