namespace Profit.UnitTests.Tests.Domain;

public sealed class MeasurementUnitTests
{
    [Theory]
    [InlineData(EMeasurementUnit.Milligram, EMeasurementUnit.Gram)]
    [InlineData(EMeasurementUnit.Gram, EMeasurementUnit.Kilogram)]
    [InlineData(EMeasurementUnit.Kilogram, EMeasurementUnit.Gram)]
    [InlineData(EMeasurementUnit.Milliliter, EMeasurementUnit.Liter)]
    [InlineData(EMeasurementUnit.Liter, EMeasurementUnit.Milliliter)]
    [InlineData(EMeasurementUnit.Unit, EMeasurementUnit.Unit)]
    public void CheckForInvalidConversions_ValidConversions_DoNotThrow(EMeasurementUnit currentUnit, EMeasurementUnit incomingUnit)
    {
        var exception = Record.Exception(() => currentUnit.CheckForInvalidConversions(incomingUnit));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(EMeasurementUnit.Milligram, EMeasurementUnit.Liter)]
    [InlineData(EMeasurementUnit.Gram, EMeasurementUnit.Unit)]
    [InlineData(EMeasurementUnit.Kilogram, EMeasurementUnit.Milliliter)]
    [InlineData(EMeasurementUnit.Milliliter, EMeasurementUnit.Gram)]
    [InlineData(EMeasurementUnit.Liter, EMeasurementUnit.Milligram)]
    [InlineData(EMeasurementUnit.Unit, EMeasurementUnit.Liter)]
    public void CheckForInvalidConversions_InvalidConversions_ThrowInvalidMeasurementConversionException(EMeasurementUnit currentUnit, EMeasurementUnit incomingUnit)
    {
        Assert.Throws<InvalidMeasurementConversionException>(() => currentUnit.CheckForInvalidConversions(incomingUnit));
    }
}