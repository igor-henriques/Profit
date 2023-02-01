namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class UserFluentMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Guid);
        builder.Property(x => x.Guid).ValueGeneratedOnAdd();
        builder.Property(x => x.Username).IsRequired();
        builder.Property(x => x.HashedPassword).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.IsEmailVerified).IsRequired();

        builder.HasMany(x => x.UserClaims)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}
