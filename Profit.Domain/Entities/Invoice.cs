namespace Profit.Domain.Entities;

public sealed record Invoice : Entity<Invoice>
{
    public Guid OrderId { get; init; }
    public Order Order { get; init; }
    public string InvoiceNumber { get; init; }
    public string InvoiceSeries { get; init; }
    public DateTime IssuedAt { get; init; }
    public string OperationNature { get; init; }
    public decimal IcmsValue { get; init; }
    public decimal IpiValue { get; init; }
    public decimal PisValue { get; init; }
    public decimal CofinsValue { get; init; }
    public string Cfop { get; init; }
    public string AccessKey { get; init; }

    public override Invoice Update(Invoice entity)
    {
        throw new NotImplementedException();
    }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}
