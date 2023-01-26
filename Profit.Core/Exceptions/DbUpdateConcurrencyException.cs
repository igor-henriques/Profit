namespace Profit.Core.Exceptions;

/// <summary>
/// This class is only used to expose the exception type to the domain interface summary
/// </summary>
public sealed class DbUpdateConcurrencyException : Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException
{
}
