namespace Profit.Infrastructure.Repository.EFInterceptors;

public sealed class SchemaInterceptor : DbCommandInterceptor
{
    private readonly ITenantInfo _tenantInfo;

    public SchemaInterceptor(ITenantInfo tenantInfo)
    {
        _tenantInfo = tenantInfo;
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        command.CommandText = ReplaceSchema(command.CommandText);
        return base.ReaderExecuting(command, eventData, result);
    }
    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
    {
        command.CommandText = ReplaceSchema(command.CommandText);
        return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    public string ReplaceSchema(string commandText)
    {
        return commandText.Replace("[dbo].", $"[{_tenantInfo.FormattedTenantId}].");
    }
}
