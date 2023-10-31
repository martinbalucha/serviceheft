using ServiceHeft.Webservice.CarMaintenance;

namespace ServiceHeft.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddApplicationPart(typeof(CarController).Assembly);
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

        app.MapControllers();

        app.Run();
    }
}
