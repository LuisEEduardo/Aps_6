using App.Data;
using App.Models.ContextoDados;
using App.Repositorio.Interface.ContextoDados;
using Microsoft.EntityFrameworkCore;

namespace App.Repositorio.Implementacao.ContextoDados;

public class DadosRepositorio : BaseRepositorio<Dados>, IDadosRepositorio
{
    public DadosRepositorio(Contexto contexto) : base(contexto)
    {
    }

    public async Task<List<Dados>> SelecionarPorTipoPermissao(int tipoPermissao)
    {
        var query = _contexto.Dados.AsQueryable();

        List<Dados> dados = new();

        if (tipoPermissao == 1)
        {
            dados = await query.ToListAsync();
        }
        else if (tipoPermissao == 2)
        {
            dados = await query.Where(x => ((int)x.NivelInformacao) != 1).ToListAsync();
        }
        else if (tipoPermissao == 3)
        {
            dados = await query
                            .Where(x => ((int)x.NivelInformacao) == 3)
                            .ToListAsync();
        }

        return dados;
    }
}
