using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace ServiceHeft.Maintenance.Infrastructure.Test.Utils;

public static class TestConfigurationBuilder
{
    public static IConfigurationRoot Build(string jsonConfiguration)
    {
        return new ConfigurationBuilder()
            .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(jsonConfiguration)))
            .Build();
    }

    public static IConfigurationRoot Build(object configuration)
    {
        string jsonConfiguration = JsonSerializer.Serialize(configuration);
        return Build(jsonConfiguration);
    }
}
