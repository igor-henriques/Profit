namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class InvoiceFluentMapping : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasMaxLength(64);
        builder.Property(i => i.InvoiceNumber).HasMaxLength(200).IsRequired();
        builder.Property(i => i.InvoiceSeries).HasMaxLength(200).IsRequired();
        builder.Property(i => i.OperationNature).HasMaxLength(200).IsRequired();
        builder.Property(i => i.Cfop).HasMaxLength(200).IsRequired();
        builder.Property(i => i.AccessKey).HasMaxLength(200).IsRequired();
        builder.HasOne(i => i.Order).WithOne(o => o.Invoice).HasForeignKey<Invoice>(i => i.OrderId);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
