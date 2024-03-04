namespace Profit.Domain.Exceptions;

public sealed class InvalidMeasurementConversionException : Exception
{
    public InvalidMeasurementConversionException(EMeasurementUnit currentUnit, EMeasurementUnit incomingUnit) : base($"{currentUnit} is not convertible to {incomingUnit}")
    {

    }
}
