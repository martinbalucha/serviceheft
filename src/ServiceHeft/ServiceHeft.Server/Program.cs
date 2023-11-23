using Microsoft.EntityFrameworkCore;
using ServiceHeft.Persistence.EntityFramework.DataAccess;
using ServiceHeft.Server.Application.Configuration;
using ServiceHeft.Webservice.CarMaintenance;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("SqlServerConfiguration.json");

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
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseKestrel(o => o.AllowAlternateSchemes = true);

var app = builder.Build();

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