namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class UserFluentMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.TenantId).ValueGeneratedOnAdd();
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Username).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthUsername);
        builder.Property(u => u.HashedPassword).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthHashedPassword);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthEmail);
        builder.Property(u => u.IsEmailVerified).IsRequired();

        builder.HasMany(u => u.UserClaims)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired();
    }
}
