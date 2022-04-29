using BML_Controls_Backend.API.Extensions;
using BML_Controls_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BML_Controls_Backend.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<User>()
                .HasMany(p => p.Companies)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(40);

            builder.Entity<Admin>().ToTable("Admins");
            builder.Entity<Admin>().HasKey(p => p.Id);
            builder.Entity<Admin>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Admin>().Property(p => p.Name).IsRequired().HasMaxLength(40);

            builder.ApplySnakeCaseNamingConvetion();
        }

    }
}
