using App.DTO.Dados;

namespace App.Application;

public interface IDadosAplicacao
{
    Task<List<DetalharDadoDTO>> SelecionarTodosDados();
}
