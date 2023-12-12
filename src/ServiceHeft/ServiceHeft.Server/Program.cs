using Microsoft.EntityFrameworkCore;
using Serilog;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Common.Persistence;
using ServiceHeft.Maintenance.Domain.Automotive;
using ServiceHeft.Persistence.EntityFramework;
using ServiceHeft.Persistence.EntityFramework.DataAccess;
using ServiceHeft.Persistence.EntityFramework.DataSeeding;
using ServiceHeft.Server.Application.Configuration;
using ServiceHeft.Webservice.CarMaintenance;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("SqlServerConfiguration.json");
builder.Configuration.AddJsonFile("loggerSettings.json");
builder.Configuration.AddJsonFile("DataSeedingConfigurations.json");

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(CarController).Assembly);

builder.Services.AddDbContext<ServiceHeftDbContext>(dbContextBulder =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

    dbContextBulder.UseSqlServer(connectionString, sqlServerAction =>
    {
        var sqlServerConfiguration = builder.Configuration.GetSection(nameof(SqlServerConfiguration)).Get<SqlServerConfiguration>() 
                                        ?? throw new ArgumentException("The SQL Server configuration is missing.");

        sqlServerAction.EnableRetryOnFailure(sqlServerConfiguration.RetryOnFailureCount);
        sqlServerAction.CommandTimeout(sqlServerConfiguration.CommandTimeoutInSeconds);
    });
}, ServiceLifetime.Singleton);

// Automotive
builder.Services.AddSingleton<ICarService, CarService>();

// Persistence
builder.Services.AddSingleton<IRepository<Car>, EntityFrameworkRepository<Car>>();
builder.Services.AddSingleton<IUnitOfWork, EntityFrameworkUnitOfWork>();
builder.Services.AddSingleton<ISeedingDataRepositoryFactory, SeedingDataRepositoryFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Logging
builder.Host.UseSerilog((ctx, config) =>
{
    config.ReadFrom.Configuration(ctx.Configuration);
});

builder.WebHost.UseKestrel(o => o.AllowAlternateSchemes = true);

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Serviceheft API");
});

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();