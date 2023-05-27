namespace Profit.Domain.Extensions;

internal static class MeasurementExtensions
{
    /// <summary>
    /// Throw <see cref="InvalidMeasurementConversionException"/> if the conversion attempt is invalid.
    /// </summary>
    /// <param name="currentUnit"></param>
    /// <param name="incomingUnit"></param>
    /// <exception cref="InvalidMeasurementConversionException"></exception>
    public static void CheckForInvalidConversions(this EMeasurementUnit currentUnit, EMeasurementUnit incomingUnit)
    {
        bool isInvalidConversion = currentUnit switch
        {
            EMeasurementUnit.Milligram => incomingUnit is not (EMeasurementUnit.Gram or EMeasurementUnit.Kilogram or EMeasurementUnit.Milligram),
            EMeasurementUnit.Gram => incomingUnit is not (EMeasurementUnit.Milligram or EMeasurementUnit.Kilogram or EMeasurementUnit.Gram),
            EMeasurementUnit.Kilogram => incomingUnit is not (EMeasurementUnit.Milligram or EMeasurementUnit.Gram or EMeasurementUnit.Kilogram),
            EMeasurementUnit.Milliliter => incomingUnit is not (EMeasurementUnit.Liter or EMeasurementUnit.Milliliter),
            EMeasurementUnit.Liter => incomingUnit is not (EMeasurementUnit.Milliliter or EMeasurementUnit.Liter),
            EMeasurementUnit.Unit => incomingUnit is not EMeasurementUnit.Unit,
            _ => false
        };

        if (isInvalidConversion)
        {
            throw new InvalidMeasurementConversionException($"{currentUnit} is not convertible to {incomingUnit}");
        }
    }
}
