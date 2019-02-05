using System.Threading.Tasks;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Usuarios
{
    public class UsuarioCadastro
    {
        public static string EmailJaExistente = "Email já cadastrado";
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioCadastro(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ArmazenarAsync(string id, string nome, string email, string senha, string permissao)
        {
            var usuario = await _usuarioRepositorio.ObterPorIdAsync(id);
            
            if(usuario == null)
            {
                await ChecarExistenciaDoEmail(email);

                usuario = new Usuario(nome, email, senha, permissao);
                usuario.CriptografarSenha(senha);
            }
            else
            {
                if (usuario.Email != email) 
                    await ChecarExistenciaDoEmail(email);

                usuario.Alterar(nome, email, permissao);
            }

            await _usuarioRepositorio.SalvarAsync(usuario);
        }

        private async Task ChecarExistenciaDoEmail(string email)
        {
            var usuarioComEmailJaExistente = await _usuarioRepositorio.ObterPorEmailAsync(email);
            if (usuarioComEmailJaExistente != null)
                throw new DominioException("UsuarioCadastro.ArmazenarAsync", EmailJaExistente);
        }
    }
}