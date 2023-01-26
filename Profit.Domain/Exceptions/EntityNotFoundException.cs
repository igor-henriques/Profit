namespace Profit.Domain.Exceptions;

public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName) : base(GetExceptionMessage(entityName)) { }

    public EntityNotFoundException(Guid guid, string entityName) : base(GetExceptionMessage(guid, entityName)) { }

    private static string GetExceptionMessage(Guid guid, string entityName)
    {
        return $"Entity of type {entityName} with guid {guid} was not found.";
    }
    private static string GetExceptionMessage(string entityName)
    {
        return $"Entity of type {entityName} was not found.";
    }
}
