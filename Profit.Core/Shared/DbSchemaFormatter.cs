namespace Profit.Core.Shared;

public static class DbSchemaFormatter
{
    public static string FormatTenantToSchema(this Guid tenantId)
    {
        return $"db_{CompiledRegex.CheckSpecialCharacterRegex().Replace(tenantId.ToString(), string.Empty)}";
    }
}
