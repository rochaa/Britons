using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sipsa.Dominio.Usuarios;

namespace sipsa.Dados.Repositorios
{
    public class UsuarioRepositorio : _RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SipsaContexto contexto)
        : base(contexto)
        {
            
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await ObterTodos()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}