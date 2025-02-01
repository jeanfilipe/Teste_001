using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste_001.Infrastructure.Entities;
using Teste_001.Infrastructure.Extensions;

namespace Teste_001.Infrastructure.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasKey(x => x.Id);
            builder.ToTable("users");

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50); ;
            builder.Property(x => x.IsActive).IsRequired();

            builder.HasData(new User { Id = 1, Name = "Jean", Email = "usuario@gmail.com", IsActive = true, Password = "123456" });
        }
    }
}