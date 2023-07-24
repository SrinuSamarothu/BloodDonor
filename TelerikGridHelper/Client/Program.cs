using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelerikGridHelper.Client;
using ProtoBuf.Grpc.Client;
using TelerikGridHelper.Shared.ServiceContracts;
using TelerikGridHelper.Client.ViewBase.Proxies;
using TelerikGridHelper.Client.ViewBase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTelerikBlazor();


builder.Services.AddSingleton(services =>
{
    var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());

    return GrpcChannel.ForAddress(
        builder.HostEnvironment.BaseAddress,
        new GrpcChannelOptions
        {
            HttpClient = new HttpClient(httpHandler)
        });
});



builder.Services.AddScoped<Func<IPanelState>>(services => () =>
{
    var channel = services.GetRequiredService<GrpcChannel>();
    var client = channel.CreateGrpcService<IPanelState>();
    return client;
});


builder.Services.AddScoped<ViewBaseModel>();
builder.Services.AddScoped<IPanelState, PanelStateProxy>();

await builder.Build().RunAsync();
