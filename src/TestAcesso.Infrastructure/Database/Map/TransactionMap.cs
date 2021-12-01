using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAcesso.Infrastructure.Database.Entities;

namespace TestAcesso.Infrastructure.Database.Map
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Type).HasConversion<string>();
        }
    }
}
