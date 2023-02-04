namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class UserClaimFluentMapping : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.HasKey(x => x.Guid);
        builder.Property(x => x.Guid).ValueGeneratedOnAdd();
        builder.Property(x => x.ClaimType).IsRequired();
        builder.Property(x => x.ClaimValue).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserClaims)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}
