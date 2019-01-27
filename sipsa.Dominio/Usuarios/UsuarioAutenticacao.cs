using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using sipsa.Dominio._Util;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Usuarios
{
    public class UsuarioAutenticacao
    {
        public static string UsuarioNaoEncontrado = "Usuário não encontrado";
        public static string SenhaIncorreta = "Senha incorreta";
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAutenticacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            var usuario = await _usuarioRepositorio.ObterPorEmail(email);
            if (usuario == null)
                throw new DominioException(nameof(Usuario), UsuarioNaoEncontrado);
            
            var senhaDb = Password.DecryptString(usuario.Senha, Environment.GetEnvironmentVariable("KeyPassword"));
            if (senhaDb != senha)
                throw new DominioException(nameof(Usuario), SenhaIncorreta);

            return usuario;
        }

        public ClaimsPrincipal CriarCookie(Usuario usuario)
        {
            // Informações pessoais do usuário.
            var direitos = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim("Nome", usuario.Nome),
                new Claim(ClaimTypes.Role, usuario.Permissao)
            };

            // Adiciona as configurações.
            var identificadorDosDireitos = new ClaimsIdentity(direitos, "login");
            return new ClaimsPrincipal(identificadorDosDireitos);
        }
    }
}