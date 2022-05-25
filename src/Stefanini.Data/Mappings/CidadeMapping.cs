using Stefanini.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stefanini.Data.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.HasMany(p => p.Pessoas)
                .WithOne(c => c.Cidade)
                .HasForeignKey(c => c.Id_Cidade);

            builder.ToTable("Cidade");
        }
    }
}
