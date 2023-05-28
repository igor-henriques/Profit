namespace Profit.Domain.Models;

/// <summary>
/// Responsible for carrying and managing the current tenant id throughout the scoped pipeline
/// </summary>
public sealed record TenantInfo : ITenantInfo
{
    private Guid _tenantId;
    public Guid TenantId
    {
        get
        {
            if (_tenantId == Guid.Empty)
            {
                throw new InvalidOperationException($"{nameof(TenantId)} is empty. Set a value for it by using {nameof(SetTenantId)}");
            }

            return _tenantId;
        }
    }
    public string FormattedTenantId => TenantId.FormatTenantToSchema();

    public void SetTenantId(Guid tenantId)
    {
        if (tenantId == Guid.Empty)
        {
            throw new ArgumentException("TenantId cannot be empty", nameof(tenantId));
        }

        _tenantId = tenantId;
    }
}
