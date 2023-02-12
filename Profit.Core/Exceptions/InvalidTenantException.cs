namespace Profit.Core.Exceptions;

public sealed class InvalidTenantException : Exception
{
    public InvalidTenantException(string description = null) : base(description) { }
}
