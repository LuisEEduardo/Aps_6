using App.Models.ContextoUsuario;

namespace App.Application;

public interface IUsuarioAplicacao 
{
    Task<Usuario> SelecionarPorId(int id);
}
