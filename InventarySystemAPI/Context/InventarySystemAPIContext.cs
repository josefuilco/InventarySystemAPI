using InventarySystemAPI.Modules.Authentication.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace InventarySystemAPI.Context
{
    public class InventarySystemAPIContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public InventarySystemAPIContext(DbContextOptions<InventarySystemAPIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Entidad User
            builder.Entity<User>(options => {
                options.ToTable("users");
                options.HasKey(u => u.UserId)
                    .HasName("user_id");
                options.Property(u => u.UserId)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsRequired();
                options.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_name")
                    .HasMaxLength(24)
                    .IsRequired();
                options.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_password")
                    .HasMaxLength(24)
                    .IsRequired();
                options.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnType("varchar")
                    .HasColumnName("user_email")
                    .HasMaxLength(50)
                    .IsRequired();
                options.Property(e => e.Active)
                    .HasColumnType("bit")
                    .HasColumnName("user_active")
                    .IsRequired();
            });
        }
    }
}