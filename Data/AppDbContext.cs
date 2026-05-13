using APIsprint.Models;
using Microsoft.EntityFrameworkCore;

namespace APIsprint.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Agency> Agencies { get; set; }

        public DbSet<AgencyLocalization> AgencyLocalizations { get; set; }

        public DbSet<FinanceOperation> FinanceOperations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasIndex(p => p.cpf)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.email)
                .IsUnique();
        }
    }
}