using ControleRotas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleRotas.Mapping
{
    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");
            builder.HasKey(p => p.EmailId);

            builder.Property(i => i.EndEmail)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.HasData(new Email
            {
                EmailId = 1,
                EndEmail = "tiago.rds85@hotmail.com",
            });
        }
    }
}
