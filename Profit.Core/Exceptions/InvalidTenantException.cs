namespace Profit.Core.Exceptions;

public sealed class InvalidTenantException : Exception
{
    public InvalidTenantException(string description) : base(description) { }
}
