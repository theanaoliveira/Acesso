using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using TestAcesso.Infrastructure.Database.Entities;
using TestAcesso.Infrastructure.Database.Map;

namespace TestAcesso.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<AccountTransfer> AccountTransfers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("CONN") != null)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONN"), sqlServerOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2);
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("TestAcessoInMemory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new AccountTransferMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
