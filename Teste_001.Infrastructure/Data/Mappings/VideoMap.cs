using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste_001.Infrastructure.Entities;
using Teste_001.Infrastructure.Extensions;

namespace Teste_001.Infrastructure.Data.Mappings
{
    public class VideoMap : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ConfigureBaseEntity();

            builder.HasKey(x => x.Id);
            builder.ToTable("videos");

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.VideoId).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();

            //builder.HasData(
            //   new Video { Id = 1, Author = "Jean", Title = "Teste 1", CreationDate = DateTime.Now, IsActive = true, Duration = TimeSpan.Parse("20") }
            //   );
        }
    }
}