using NetArchTest.Rules;
using ServiceHeft.Maintenance.Contracts;
using Xunit;

namespace ServiceHeft.Architecture.Test.Contracts;

public class MaintenanceTest
{
    private const string ContractsNamespace = "ServiceHeft.Maintenance.Contracts";
    private const string DomainNamespace = "ServiceHeft.Maintenance.Domain";
    private const string EntityFrameworkNamespace = "ServiceHeft.Persistence.EntityFramework";
    private const string WebserviceNamespace = "ServiceHeft.Maintenance.Webservice";

    [Fact]
    public void Contracts_ShouldNot_DependOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Entity).Assembly;

        var otherDependencies = new[]
        {
            DomainNamespace,
            EntityFrameworkNamespace,
            WebserviceNamespace
        };

        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherDependencies).GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    
}
