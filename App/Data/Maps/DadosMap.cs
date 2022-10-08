using App.Models.ContextoDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Maps;

public class DadosMap : IEntityTypeConfiguration<Dados>
{
    public void Configure(EntityTypeBuilder<Dados> builder)
    {
        builder.ToTable("Dados");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id);

        builder
            .Property(x => x.Propriedade)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.ProdutoQuimico)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.NivelInformacao)
            .HasColumnType("int")
            .IsRequired();
    }
}
