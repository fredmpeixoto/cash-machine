using CashMachine.Domain.Entitys;
using CashMachine.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace CashMachine.Infra.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Account>().ToTable("Account");

            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
