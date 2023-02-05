﻿namespace Profit.Infrastructure.Repository.DataContext.EntityMapping;

public sealed class UserFluentMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Username).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthName);
        builder.Property(x => x.HashedPassword).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthHashedPassword);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(Constants.FieldsDefinitions.MaxLengthEmail);
        builder.Property(x => x.IsEmailVerified).IsRequired();

        builder.HasMany(x => x.UserClaims)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();
    }
}
