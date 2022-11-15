using App.Models.ContextoUsuario;
using App.Repositorio.Interface.ContextoUsuario;

namespace App.Application.implementation;

public class UsuarioAplicacao : IUsuarioAplicacao
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task<Usuario> SelecionarPorId(int id)
    {
        var usuario = await _usuarioRepositorio.SelecionarPorId(x => x.Id == id);
        return usuario;
    }
}
