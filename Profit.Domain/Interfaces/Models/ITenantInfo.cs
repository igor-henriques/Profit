namespace Profit.Domain.Interfaces.Models;

public interface ITenantInfo
{
    string FormattedTenantId { get; }
    Guid TenantId { get; }

    bool Equals(TenantInfo other);
    void SetTenantId(Guid tenantId);
}