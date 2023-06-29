using Bank.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data;
public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options) { }

    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<AccountEntity> Accounts { get; set; } = null!;
    public DbSet<TransactionEntity> Transactions { get; set; } = null!;
}
