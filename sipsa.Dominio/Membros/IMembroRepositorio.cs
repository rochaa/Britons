using System.Collections.Generic;
using System.Threading.Tasks;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public interface IMembroRepositorio : IRepositorio<Membro> {
        Task<List<Membro>> ObterOsUltimosMembrosModificadosAsync();
    }
}