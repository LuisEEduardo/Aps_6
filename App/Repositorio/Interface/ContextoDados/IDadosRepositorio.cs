using App.Models.ContextoDados;

namespace App.Repositorio.Interface.ContextoDados;

public interface IDadosRepositorio : IBaseRepositorio<Dados>
{
    Task<List<Dados>> SelecionarPorTipoPermissao(int tipoPermissao);
}
