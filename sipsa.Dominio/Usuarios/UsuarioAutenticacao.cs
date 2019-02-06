using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using sipsa.Dominio._Base;
using sipsa.Dominio._Util;

namespace sipsa.Dominio.Usuarios {
    public class UsuarioAutenticacao {
        public static string UsuarioNaoEncontrado = "Usuário não encontrado";
        public static string SenhaIncorreta = "Senha incorreta";
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAutenticacao (IUsuarioRepositorio usuarioRepositorio) {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> AutenticarAsync (string email, string senha) {
            var usuario = await _usuarioRepositorio.ObterPorEmailAsync (email);
            if (usuario == null)
                throw new DominioExcecao ("UsuarioAutenticacao.Autenticar", UsuarioNaoEncontrado);

            var senhaDb = Password.DecryptString (usuario.Senha, Environment.GetEnvironmentVariable ("KeyPassword"));
            if (senhaDb != senha)
                throw new DominioExcecao ("UsuarioAutenticacao.Autenticar", SenhaIncorreta);

            return usuario;
        }

        public ClaimsPrincipal CriarCookie (Usuario usuario) {
            // Informações pessoais do usuário.
            var direitos = new List<Claim> {
                new Claim (ClaimTypes.Name, usuario.Email),
                new Claim ("Nome", usuario.Nome),
                new Claim (ClaimTypes.Role, usuario.Permissao)
            };

            // Adiciona as configurações.
            var identificadorDosDireitos = new ClaimsIdentity (direitos, "login");
            return new ClaimsPrincipal (identificadorDosDireitos);
        }
    }
}