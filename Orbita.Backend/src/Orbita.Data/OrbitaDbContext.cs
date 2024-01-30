using Microsoft.EntityFrameworkCore;
using Orbita.Model;

namespace Orbita.Data 
{
    public class OrbitaDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }


        public OrbitaDbContext(DbContextOptions<OrbitaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.RA);
        }
    }
}
