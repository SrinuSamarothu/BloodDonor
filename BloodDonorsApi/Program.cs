using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User Id=cnu;Password={dbPassword}";
builder.Services.AddDbContext<DonorContext>(options => options.UseSqlServer(connectionString));*/

builder.Services.AddDbContext<DonorContext>(options => options.UseSqlServer("Server=Cnu;Database=DonorDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;", b => b.MigrationsAssembly("BloodDonorsApi"))); 

// "Server=Cnu;Database=DonorDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;", b => b.MigrationsAssembly("BloodDonorsApi")

builder.Services.AddScoped<IRepo, Repo>();

var AllowAllPolicy = "AllowAllPolicy";
builder.Services.AddCors(options =>
options.AddPolicy(AllowAllPolicy, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
