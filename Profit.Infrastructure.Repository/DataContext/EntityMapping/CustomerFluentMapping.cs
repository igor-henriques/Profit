namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class CustomerFluentMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasMaxLength(64);
        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Document).HasMaxLength(20);
        builder.HasMany(c => c.Addresses).WithOne().HasForeignKey(a => a.CustomerId);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
