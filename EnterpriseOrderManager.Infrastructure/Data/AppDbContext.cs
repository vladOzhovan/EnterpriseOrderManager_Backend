using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EnterpriseOrderManager.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EnterpriseOrderManager.Infrastructure.Data.Entities;

namespace EnterpriseOrderManager.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<CounterEntity> Counters => Set<CounterEntity>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderEntity>().Property(o => o.Status).HasConversion<string>();
            builder.Entity<OrderEntity>().HasIndex(x => x.OrderNumber).IsUnique();
            builder.Entity<CustomerEntity>().OwnsOne(c => c.Address);
            builder.Entity<CustomerEntity>().HasIndex(x => x.CustomerNumber).IsUnique();
            builder.Entity<CustomerEntity>().Navigation(x => x.Address).IsRequired();
            builder.Entity<CounterEntity>(b =>
            {
                b.HasKey(x => x.Name);
                b.Property(x => x.Value).IsRequired();
                b.HasData(new CounterEntity { Name = "CustomerNumber", Value = 0 });
            });

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "ROLE_ADMIN",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "ROLE_MODERATOR",
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Id = "ROLE_USER",
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
