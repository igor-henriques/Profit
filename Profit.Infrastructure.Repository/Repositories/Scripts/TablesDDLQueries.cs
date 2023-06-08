namespace Profit.Infrastructure.Repository.Repositories.Scripts;

internal static class TablesDDLQueries
{
    private const string DROP_TABLE_QUERY = """
            IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}' AND TABLE_SCHEMA = '{1}')
        BEGIN
            DROP TABLE [{1}].[{0}];
        END
        """;

    public static string GetDropTableQuery(string tableName, string schemaName) => string.Format(DROP_TABLE_QUERY, tableName, schemaName);
}