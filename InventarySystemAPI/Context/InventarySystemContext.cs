using InventarySystemAPI.Modules.Authentication.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace InventarySystemAPI.Context
{
    public class InventarySystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public InventarySystemContext(DbContextOptions<InventarySystemContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Entidad User
            builder.Entity<User>(entity => {
                entity.ToTable("users");
                entity.HasKey(u => u.UserId)
                    .HasName("user_id");
                entity.Property(u => u.UserId)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsRequired();
                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_name")
                    .HasMaxLength(24)
                    .IsRequired();
                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_password")
                    .HasMaxLength(24)
                    .IsRequired();
                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_email")
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.Active)
                    .HasColumnType("bit")
                    .HasColumnName("user_active")
                    .IsRequired();
            });
        }
    }
}