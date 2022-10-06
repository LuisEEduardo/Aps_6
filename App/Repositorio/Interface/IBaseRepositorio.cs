using System.Linq.Expressions;

namespace App.Repositorio.Interface;

public interface IBaseRepositorio<T>
{
    IQueryable<T> Selecionar();
    Task<T> SelecionarPorId(Expression<Func<T, bool>> predicate);
    Task Adicionar(T entidade);
    Task Atualizar(T entidade);
    Task Remover(T entidade);
    Task Salvar();
}
