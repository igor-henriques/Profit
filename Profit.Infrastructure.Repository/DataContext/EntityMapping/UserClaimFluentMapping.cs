namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class UserClaimFluentMapping : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.HasKey(uc => uc.Guid);
        builder.ToTable(Constants.TableNames.UserClaim);
        builder.Property(uc => uc.Guid).ValueGeneratedOnAdd();
        builder.Property(uc => uc.ClaimType).IsRequired();
        builder.Property(uc => uc.ClaimValue).IsRequired();
        builder.Property(uc => uc.UserId).IsRequired();

        builder.HasOne(uc => uc.User)
            .WithMany(uc => uc.UserClaims)
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();
    }
}
