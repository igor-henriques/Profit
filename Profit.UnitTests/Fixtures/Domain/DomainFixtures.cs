namespace Profit.UnitTests.Fixtures.Domain;

internal static class DomainFixtures
{
    internal static (string, decimal, decimal, EMeasurementUnit, string) GetInvalidIngredientData => ("", -1, -1, EMeasurementUnit.Gram, "");
    internal static (string, decimal, decimal, EMeasurementUnit, string) GetValidIngredientData => new("test", 1, 1, EMeasurementUnit.Milligram, "test");
}
