using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sipsa.Dominio._Base
{
    public interface IRepositorio<TEntidade>
    {
        Task<List<TEntidade>> ObterTodosAsync();

        Task<TEntidade> ObterPorIdAsync(string id);

        Task SalvarAsync(TEntidade entidade);

        Task RemoverAsync(TEntidade entidade);
    }
}