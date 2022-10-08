using App.Data.Maps;
using App.Models.ContextoDados;
using App.Models.ContextoUsuario;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class Contexto : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Dados> Dados { get; set; }

    public Contexto(DbContextOptions<Contexto> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new DadosMap());

        base.OnModelCreating(modelBuilder);
    }

}
