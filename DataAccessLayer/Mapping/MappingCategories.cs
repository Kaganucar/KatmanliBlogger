using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    public class MappingCategories : IEntityTypeConfiguration<TBLCategories>
    {
        public void Configure(EntityTypeBuilder<TBLCategories> builder)
        {
            builder.HasKey(x=> x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.CategoryName).HasMaxLength(50);

            // Her Bir kategorinin Birden Fazla Blogu olur.
            builder.HasMany(x => x.TBLBlog).WithOne(x=> x.TBLCategories).HasForeignKey(x=> x.CategoriesId);

            builder.ToTable("TBLCategories");
        }
    }
}
