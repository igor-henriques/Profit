namespace Profit.UnitTests.Tests.Interceptors;

public sealed class SchemaInterceptorTests
{
    [Fact]
    public void ReplaceSchema_ShouldReplaceDboSchemaWithFormattedTenantId()
    {
        // Arrange
        string schemaName = Guid.NewGuid().FormatTenantToSchema();

        var mockTenantInfo = new Mock<ITenantInfo>();
        mockTenantInfo.Setup(t => t.FormattedTenantId).Returns(schemaName);

        var interceptor = new SchemaInterceptor(mockTenantInfo.Object);

        var commandText = "[dbo].TableName";

        // Act
        var result = interceptor.ReplaceSchema(commandText);

        // Assert
        Assert.Equal($"[{schemaName}].TableName", result);
    }
}
