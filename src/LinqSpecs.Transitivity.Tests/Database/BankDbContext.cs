using LinqSpecs.Transitivity.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqSpecs.Transitivity.Tests.Database;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Client>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Client>()
            .HasOne(o => o.Citizenship)
            .WithMany(c => c.Citizens)
            .HasForeignKey(o=> o.CitizenshipId);

        modelBuilder.Entity<Client>()
            .HasMany<Account>(o=> o.Accounts)
            .WithOne(o => o.Client)
            .HasForeignKey(o => o.ClientId);
    }
}