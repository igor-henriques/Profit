namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class OrderFluentMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).HasMaxLength(64);
        builder.Property(o => o.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
        builder.HasMany(o => o.OrderDetails).WithOne(od => od.Order).HasForeignKey(od => od.OrderId);
        builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
        builder.HasOne(o => o.Address).WithOne().HasForeignKey<Order>(o => o.AddressId);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
