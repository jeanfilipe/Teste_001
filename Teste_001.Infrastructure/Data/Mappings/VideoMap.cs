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

            builder.Property(estado => estado.Id).IsRequired();
            builder.Property(estado => estado.VideoId).IsRequired().HasMaxLength(20);
            builder.Property(estado => estado.Title).IsRequired().HasMaxLength(200);
            builder.Property(estado => estado.Duration).IsRequired();
            builder.Property(estado => estado.Author).IsRequired();
            builder.Property(estado => estado.CreationDate).IsRequired();
            builder.Property(estado => estado.IsActive).IsRequired();

            //builder.HasData(
            //   new Video { Id = 1, Author = "Jean", Title = "Teste 1", CreationDate = DateTime.Now, IsActive = true, Duration = TimeSpan.Parse("20") }
            //   );
        }
    }
}