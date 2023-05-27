namespace Profit.Domain.Exceptions;

public sealed class InvalidMeasurementConversionException : Exception
{
    public InvalidMeasurementConversionException(string message) : base(message)
    {

    }
}
