using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sipsa.Dominio._Base;

namespace sipsa.Dados.Repositorios
{
    public class _RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : class, IEntidade
    {
        private readonly SipsaContexto _contexto;

        public _RepositorioBase(SipsaContexto  contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<TEntidade> ObterTodos()
        {
            return _contexto.Set<TEntidade>().AsNoTracking();
        }

        public async Task<TEntidade> ObterPorId(int id)
        {
            return await _contexto.Set<TEntidade>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Criar(TEntidade entidade)
        {
            await _contexto.Set<TEntidade>().AddAsync(entidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task Atualizar(int id, TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Update(entidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var entidade = await _contexto.Set<TEntidade>().FindAsync(id);
            _contexto.Set<TEntidade>().Remove(entidade);
            await _contexto.SaveChangesAsync();
        }
    }
}