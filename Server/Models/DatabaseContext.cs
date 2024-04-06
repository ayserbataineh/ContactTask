using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Contact> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contactdetails");
                entity.Property(e => e.Id).HasColumnName("Userid");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}