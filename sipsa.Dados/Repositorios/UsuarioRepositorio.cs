using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using sipsa.Dominio.Usuarios;

namespace sipsa.Dados.Repositorios
{
    public class UsuarioRepositorio : _Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SipsaContexto contexto)
        : base(contexto, Environment.GetEnvironmentVariable("TB_Usuarios"))
        {

        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            List<ScanCondition> filtros = new List<ScanCondition>
            {
                new ScanCondition("Email", ScanOperator.Equal, email)
            };

            var usuarios = await ObterComFiltrosAsync(filtros);
            return usuarios.FirstOrDefault();
        }
    }
}