using NetArchTest.Rules;
using ServiceHeft.Maintenance.Contracts.Common;
using ServiceHeft.Maintenance.Domain;
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

        var otherProjects = new[]
        {
            DomainNamespace,
            EntityFrameworkNamespace,
            WebserviceNamespace
        };

        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Domain_Should_DependSolelyOnContracts()
    {
        // Arrange
        var assembly = typeof(MaintenanceAggregatingService).Assembly;

        var otherProjects = new[]
{
            EntityFrameworkNamespace,
            WebserviceNamespace
        };

        // Act
        var dependencyOnContractsResult = Types.InAssembly(assembly).Should().HaveDependencyOn(ContractsNamespace).GetResult();
        var dependencyOnOtherProjectsResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

        // Assert
        Assert.True(dependencyOnContractsResult.IsSuccessful);
        Assert.True(dependencyOnOtherProjectsResult.IsSuccessful);
    }
}
