using App.DTO.Dados;
using App.Repositorio.Interface.ContextoDados;

namespace App.Application.implementation;

public class DadosAplicacao : IDadosAplicacao
{
    private readonly IDadosRepositorio _dadosRepositorio;

    public DadosAplicacao(IDadosRepositorio dadosRepositorio)
    {
        _dadosRepositorio = dadosRepositorio;
    }

    public async Task<List<DetalharDadoDTO>> SelecionarTodosDados()
    {
        var dados = await _dadosRepositorio.Selecionar();

        List<DetalharDadoDTO> detalharDadoDTOs = new();

        foreach (var dado in dados)
        {
            detalharDadoDTOs.Add(new DetalharDadoDTO()
            {
                ProdutoQuimico = dado.ProdutoQuimico,
                Propriedade = dado.Propriedade,
                NivelInformacao = dado.NivelInformacao
            });
        }

        return detalharDadoDTOs;
    }
}
