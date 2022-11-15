using App.DTO.Dados;

namespace App.Application;

public interface IDadosAplicacao
{
    Task<List<DetalharDadoDTO>> SelecionarTodosDados();    
    Task<List<DetalharDadoDTO>> SelecionarTodosDadosPorTipoPermissao(int tipoPermissao);    
}
