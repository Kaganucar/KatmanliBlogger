using DataAccessLayer.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    // Veritabanı Bağlantısını Sağlayan Yapımız.
    public class DatabaseContext:DbContext
    {
        public DbSet<TBLBlog> TBLBLog { get; set; }
        public DbSet<TBLUser> TBLUser { get; set; }
        public DbSet<TBLCategories> TBLCategories { get; set; }


        // Bağlantımızı yoneten metot.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //AsNoTracking'i Repository'e yazmak yerine Buraya da yazılabilir.
            optionsBuilder.UseSqlServer(@"Server=ABRA;Database=BlogKatmanli;Trusted_Connection=True;trustServerCertificate=true;");
        }

        // Mapping'lerimizi yöneten metot.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MappingCategories());
            modelBuilder.ApplyConfiguration(new MappingTBLBlog());
            modelBuilder.ApplyConfiguration(new MappingTBLUser());
        }
    }
}
