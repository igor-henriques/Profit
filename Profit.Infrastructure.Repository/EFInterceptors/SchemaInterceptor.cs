namespace Profit.Infrastructure.Repository.EFInterceptors;

public sealed class SchemaInterceptor : DbCommandInterceptor
{
    private readonly TenantInfo _tenantInfo;

    public SchemaInterceptor(TenantInfo tenantInfo)
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

    private string ReplaceSchema(string commandText)
    {
        return commandText.Replace("[dbo].", $"[{_tenantInfo.FormattedTenantId}].");
    }
}
