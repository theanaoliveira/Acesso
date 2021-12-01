using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAcesso.Infrastructure.Database.Entities;

namespace TestAcesso.Infrastructure.Database.Map
{
    public class AccountTransferMap : IEntityTypeConfiguration<AccountTransfer>
    {
        public void Configure(EntityTypeBuilder<AccountTransfer> builder)
        {
            builder.ToTable("AccountTransfer");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Status).HasConversion<string>();
        }
    }
}
