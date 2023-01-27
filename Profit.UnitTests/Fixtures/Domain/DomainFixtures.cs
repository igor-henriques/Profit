namespace Profit.UnitTests.Fixtures.Domain;

internal static class DomainFixtures
{
    internal static (string, decimal, decimal, string) GetInvalidIngredientData => ("", -1, -1, "");
    internal static (string, decimal, decimal, string) GetValidIngredientData => ("test", 1, 1, "test");
}
