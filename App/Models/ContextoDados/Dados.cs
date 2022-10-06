namespace App.Models.ContextoDados;

public class Dados
{
    public Dados(string propriedade, string produtoQuimico)
    {
        Propriedade = propriedade.Trim();
        ProdutoQuimico = produtoQuimico.Trim();
    }

    public Guid Id { get; set; }
    public string Propriedade { get; set; }
    public string ProdutoQuimico { get; set; }

    public void Editar(string propriedade, string produtoQuimico)
    {
        Propriedade = propriedade.Trim();
        ProdutoQuimico = produtoQuimico.Trim();
    }

}
