namespace Profit.UnitTests.Tests.Models;

public sealed class MeasurementUnitTests
{
    [Fact]
    public void Should_ThrowException_When_QuantityIsZero()
    {
        Assert.Throws<ArgumentException>(() => MeasurementUnit.Create(EMeasurementUnit.Gram, 0));
    }

    [Fact]
    public void Should_ThrowException_When_QuantityIsNegative()
    {
        Assert.Throws<ArgumentException>(() => MeasurementUnit.Create(EMeasurementUnit.Gram, -1));
    }

    [Fact]
    public void Should_CreateMeasurementUnit_When_ValidArgumentsAreProvided()
    {
        var unit = MeasurementUnit.Create(EMeasurementUnit.Gram, 1);
        Assert.NotNull(unit);
        Assert.Equal(1, unit.Quantity);
        Assert.Equal("Grama", unit.TranslatedName);
        Assert.Equal("g", unit.Abbreviation);
    }

    [Fact]
    public void Should_ThrowException_When_NullIngredientIsPassed()
    {
        Assert.Throws<ArgumentNullException>(() => MeasurementUnit.CreateFromIngredient(null));
    }

    [Fact]
    public void Should_ThrowException_When_NullIngredientRecipeRelationIsPassed()
    {
        Assert.Throws<ArgumentNullException>(() => MeasurementUnit.CreateFromIngredientRecipeRelation(null));
    }

    [Fact]
    public void Should_ThrowException_When_InvalidConversionIsRequested()
    {
        var unit = MeasurementUnit.Create(EMeasurementUnit.Liter, 1);
        Assert.Throws<InvalidOperationException>(() => MeasurementUnit.GetEquivalent(unit, EMeasurementUnit.Gram));
    }

    [Fact]
    public void Should_ConvertUnits_When_ValidConversionIsRequested()
    {
        var unit = MeasurementUnit.Create(EMeasurementUnit.Kilogram, 1);
        var convertedUnit = MeasurementUnit.GetEquivalent(unit, EMeasurementUnit.Gram);
        Assert.NotNull(convertedUnit);
        Assert.Equal(1000, convertedUnit.Quantity);
        Assert.Equal("Grama", convertedUnit.TranslatedName);
        Assert.Equal("g", convertedUnit.Abbreviation);
    }

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
