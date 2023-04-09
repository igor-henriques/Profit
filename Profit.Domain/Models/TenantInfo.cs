namespace Profit.Domain.Models;

public sealed record TenantInfo
{
    public Guid TenantId { get; private set; }
    
    public void SetTenantId(Guid tenantId)
    {
        TenantId = tenantId;
    }
}
