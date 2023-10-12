using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using HrmUi;
using HrmUi.IService;
using HrmUi.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7198")
});
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
await builder.Build().RunAsync();
