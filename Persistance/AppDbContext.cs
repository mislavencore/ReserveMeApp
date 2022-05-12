using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(p => p.Company)
                .WithMany(b => b.Users)
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Company>()
                .HasOne(a => a.Settings)
                .WithOne(b => b.Company)
                .HasForeignKey<Settings>(e => e.CompanyId);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Company)
                .WithMany(b => b.Items)
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Reservation>()
                .HasOne(p => p.User)
                .WithMany(b => b.Reservations)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(p => p.Item)
                .WithMany(b => b.Reservations)
                .HasForeignKey(p => p.ItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}