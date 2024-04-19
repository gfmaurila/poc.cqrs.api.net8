using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.Domain.Entities.User;
using Poc.SQLServer.Extensions;
using System.Text.Json;

namespace Poc.SQLServer.Mappings;
public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ConfigureBaseEntity();

        builder
            .Property(entity => entity.FirstName)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder
            .Property(entity => entity.LastName)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder
            .Property(entity => entity.Gender)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(6)
            .HasConversion<string>();

        builder
            .Property(entity => entity.Notification)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(10)
            .HasConversion<string>();

        //builder
        //    .Property(entity => entity.Phone.Phone)
        //    .IsRequired() // NOT NULL
        //    .IsUnicode(false) // VARCHAR
        //    .HasMaxLength(20)
        //    .HasColumnName(nameof(UserEntity.Phone));

        builder.OwnsOne(entity => entity.Phone, ownedNav =>
        {
            ownedNav
                .Property(phone => phone.Phone)
                .IsRequired() // NOT NULL
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(20)
                .HasColumnName(nameof(UserEntity.Phone));

            // Unique Index
            //ownedNav
            //    .HasIndex(phone => phone.Phone)
            //    .IsUnique();
        });

        //builder
        //    .Property(entity => entity.Email.Address)
        //    .IsRequired() // NOT NULL
        //    .IsUnicode(false) // VARCHAR
        //    .HasMaxLength(250)
        //    .HasColumnName(nameof(UserEntity.Email));

        // Mapeamento de Objetos de Valor (ValueObject)
        builder.OwnsOne(entity => entity.Email, ownedNav =>
        {
            ownedNav
                .Property(email => email.Address)
                .IsRequired() // NOT NULL
                .IsUnicode(false) // VARCHAR
                .HasMaxLength(254)
                .HasColumnName(nameof(UserEntity.Email));

            // Unique Index
            //ownedNav
            //    .HasIndex(email => email.Address)
            //    .IsUnique();
        });

        builder
            .Property(entity => entity.Password)
            .IsRequired() // NOT NULL
            .IsUnicode(false) // VARCHAR
            .HasMaxLength(100);

        builder.Property(entity => entity.RoleUserAuth)
            .IsRequired()
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
            .IsUnicode(false)
            .HasMaxLength(2048);

        builder
            .Property(entity => entity.DateOfBirth)
            .IsRequired() // NOT NULL
            .HasColumnType("DATE");
    }
}

