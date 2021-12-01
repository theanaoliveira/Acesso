using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAcesso.Infrastructure.Database.Entities;

namespace TestAcesso.Infrastructure.Database.Map
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Type).HasConversion<string>();
        }
    }
}
