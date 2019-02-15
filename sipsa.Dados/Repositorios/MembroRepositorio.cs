using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using sipsa.Dominio.Membros;

namespace sipsa.Dados.Repositorios {
    public class MembroRepositorio : _Repositorio<Membro>, IMembroRepositorio {
        public MembroRepositorio (SipsaContexto contexto) : base (contexto, Environment.GetEnvironmentVariable ("TB_Membros")) {

        }

        public async Task<List<Membro>> ObterOsUltimosMembrosModificadosAsync () {
            // List<ScanCondition> filtros = new List<ScanCondition> {
            //     new ScanCondition ("Email", ScanOperator.Equal, email)
            // };

            var membros = await ObterTodosAsync();
            return membros;
        }
    }
}