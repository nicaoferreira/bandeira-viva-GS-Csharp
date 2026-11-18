using BandeiraViva.Api.Data;
using BandeiraViva.Api.Interfaces;
using BandeiraViva.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=bandeira-viva.db"));

builder.Services.AddScoped<IBeachService, BeachService>();
builder.Services.AddScoped<IWaterReadingService, WaterReadingService>();
builder.Services.AddScoped<IAnonymousReportService, AnonymousReportService>();
builder.Services.AddScoped<IBathingStatusClassifier, BathingStatusClassifier>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
    await DatabaseSeeder.SeedAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", () => Results.Ok(new
{
    application = "Bandeira Viva API",
    status = "online",
    documentation = "/swagger"
}));

app.Run();

public partial class Program { }
