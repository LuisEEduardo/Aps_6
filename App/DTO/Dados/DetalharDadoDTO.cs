using App.Models.ContextoDados.Enum;

namespace App.DTO.Dados
{
    public class DetalharDadoDTO
    {
        public string Propriedade { get; set; }
        public string ProdutoQuimico { get; set; }
        public NivelInformacao NivelInformacao { get; set; }
    }
}
