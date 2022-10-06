using App.Data;
using App.Models.ContextoDados;
using App.Repositorio.Interface.ContextoDados;

namespace App.Repositorio.Implementacao.ContextoDados;

public class DadosRepositorio : BaseRepositorio<Dados>, IDadosRepositorio
{
    public DadosRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
