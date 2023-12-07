namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class AddressFluentMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasMaxLength(64);
        builder.Property(a => a.Street).IsRequired().HasMaxLength(250);
        builder.Property(a => a.City).IsRequired().HasMaxLength(100);
        builder.Property(a => a.State).IsRequired().HasMaxLength(100);
        builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(15);
        builder.Property(a => a.Country).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Reference).HasMaxLength(250);
        builder.Property(a => a.Observation).HasMaxLength(500);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
