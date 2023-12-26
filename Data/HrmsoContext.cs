using JinjiApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace JinjiApp1.Data
{
    public partial class HrmsoContext : DbContext
    {
        public HrmsoContext(DbContextOptions<HrmsoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
