using System.Linq;
using System.Threading.Tasks;

namespace sipsa.Dominio._Base
{
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        IQueryable<TEntidade> ObterTodos();

        Task<TEntidade> ObterPorId(int id);

        Task Criar(TEntidade entidade);

        Task Atualizar(int id, TEntidade entidade);

        Task Remover(int id);
    }
}