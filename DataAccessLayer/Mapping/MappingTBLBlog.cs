using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class MappingTBLBlog : IEntityTypeConfiguration<TBLBlog>
    {
        public void Configure(EntityTypeBuilder<TBLBlog> builder)
        {
            builder.HasKey(x => x.id); // Primary Key
            builder.Property(x => x.id).ValueGeneratedOnAdd(); // Otomatik Artan
            builder.Property(x => x.Images).HasMaxLength(50);
            builder.Property(x => x.BlogName).HasMaxLength(50);

            //Her Eklenen Blogun Bir Kategorisi olacaktır.
            //Her Bir Blog'un Bir Kategorisi Olacak.
            builder.HasOne(x => x.TBLCategories).WithMany(x => x.TBLBlog).HasForeignKey(x => x.CategoriesId);

            builder.ToTable("TBLBlog");
        }
    }
}
