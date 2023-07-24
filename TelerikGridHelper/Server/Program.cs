using Microsoft.AspNetCore.ResponseCompression;
using ProtoBuf.Grpc.Server;
using TelerikGridHelper.Server.PanelDbContext;
using TelerikGridHelper.Server.Repos;
using TelerikGridHelper.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PanelStateDbContext>();

builder.Services.AddScoped<IRepo, Repo>();

builder.Services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<PanelStateService>();
});


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
