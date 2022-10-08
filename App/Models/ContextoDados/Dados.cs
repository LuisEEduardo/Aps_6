using App.Models.ContextoDados.Enum;

namespace App.Models.ContextoDados;

public class Dados
{
    public Dados(string propriedade, string produtoQuimico, NivelInformacao nivelInformacao)
    {
        Propriedade = propriedade.Trim();
        ProdutoQuimico = produtoQuimico.Trim();
        NivelInformacao = nivelInformacao;
    }

    public Guid Id { get; set; }
    public string Propriedade { get; set; }
    public string ProdutoQuimico { get; set; }
    public NivelInformacao NivelInformacao { get; set; }

    public void Editar(string propriedade, string produtoQuimico, NivelInformacao nivelInformacao)
    {
        Propriedade = propriedade.Trim();
        ProdutoQuimico = produtoQuimico.Trim();
        NivelInformacao = nivelInformacao;
    }

}
