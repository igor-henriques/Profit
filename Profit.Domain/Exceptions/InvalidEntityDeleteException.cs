namespace Profit.Domain.Exceptions;

public sealed class InvalidEntityDeleteException : Exception
{
    public InvalidEntityDeleteException(string message) : base(message)
    {

    }
}
