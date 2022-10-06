using App.Data;
using App.Models.ContextoUsuario;
using App.Repositorio.Interface.ContextoUsuario;

namespace App.Repositorio.Implementacao.ContextoUsuario;

public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
