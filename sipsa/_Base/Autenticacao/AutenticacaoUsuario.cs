using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Configuration;
using sipsa.Models;
using sipsa.Util;

namespace sipsa._Base.Autenticacao
{
    public class AutenticacaoUsuario
    {
        private readonly DynamoDBContext db;
        private readonly IConfiguration _configuracao;

        public AutenticacaoUsuario(DynamoDBContext context, IConfiguration configuracao)
        {
            db = context;
            _configuracao = configuracao;
        }

        public async Task<Usuario> AutenticarUsuario(string email, string senha)
        {
            List<ScanCondition> conditions = new List<ScanCondition>
            {
                new ScanCondition("Email", ScanOperator.Equal, email)
            };
            var usuario = (await db.ScanAsync<Usuario>(conditions).GetRemainingAsync()).FirstOrDefault();
            if (usuario != null)
            {
                var senhaDb = Password.DecryptString(usuario.Senha, _configuracao["KeyPassword"]);
                if (senhaDb == senha)
                {
                    return usuario;
                }
            }
            return null;
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