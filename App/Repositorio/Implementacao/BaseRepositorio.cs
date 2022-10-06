using App.Data;
using App.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Repositorio.Implementacao;

public class BaseRepositorio<T> : IDisposable, IBaseRepositorio<T> where T : class
{

    protected readonly Contexto _contexto;

    public BaseRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }
    public IQueryable<T> Selecionar()
        => _contexto.Set<T>();

    public Task<T> SelecionarPorId(Expression<Func<T, bool>> predicate)
        => _contexto.Set<T>().SingleOrDefaultAsync(predicate);

    public async Task Adicionar(T entidade)
    {
        await _contexto.Set<T>().AddAsync(entidade);
        await Salvar();
    }

    public async Task Atualizar(T entidade)
    {
        _contexto.Set<T>().Update(entidade);
        await Salvar();
    }

    public async Task Remover(T entidade)
    {
        _contexto.Set<T>().Remove(entidade);
        await Salvar();
    }

    public async Task Salvar()
    {
        try
        {
            await _contexto.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new Exception("Falha interna");
        }
    }

    public void Dispose()
    {
        _contexto.Dispose();
    }

}
