namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class OrderDetailFluentMapping : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.HasKey(od => od.Id);
        builder.Property(od => od.Id).HasMaxLength(64);
        builder.Property(od => od.Quantity).IsRequired();
        builder.Property(od => od.Taxes).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(od => od.Discount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(od => od.Total).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId);
        builder.HasOne(od => od.Product).WithMany().HasForeignKey(od => od.ProductId);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
