using App.Models.ContextoUsuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(x => x.TipoPermissao)
            .HasColumnType("int")
            .IsRequired();
    }
}
