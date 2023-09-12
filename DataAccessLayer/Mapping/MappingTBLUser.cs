using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mapping
{
    public class MappingTBLUser : IEntityTypeConfiguration<TBLUser>
    {
        public void Configure(EntityTypeBuilder<TBLUser> builder)
        {
            builder.HasKey(x => x.id); // Primary Key
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.Passwords).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Roles).HasMaxLength(20);

            builder.ToTable("TBLUser");
        }
    }
}
