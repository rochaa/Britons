using System.Threading.Tasks;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Usuarios {
    public interface IUsuarioRepositorio : IRepositorio<Usuario> {
        Task<Usuario> ObterPorEmailAsync (string email);
    }
}