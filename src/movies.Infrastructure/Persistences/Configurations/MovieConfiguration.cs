using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movies.Infrastructure.Persistences.DataEntities;

namespace movies.Infrastructure.Persistences.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("id").UseIdentityColumn();
            builder.Property(m => m.Title).HasColumnName("title").HasMaxLength(500).IsRequired();
            builder.Property(m => m.Year).HasColumnName("year").HasColumnType("int");
            builder.Property(m => m.Type).HasColumnName("type").HasMaxLength(100).IsRequired();
            builder.Property(m => m.AddedDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        }
    }
}
