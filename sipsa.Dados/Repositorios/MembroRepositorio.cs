using System;
using sipsa.Dominio.Membros;

namespace sipsa.Dados.Repositorios
{
    public class MembroRepositorio : _RepositorioBase<Membro>, IMembroRepositorio
    {
        public MembroRepositorio(SipsaContexto contexto)
        : base(contexto, Environment.GetEnvironmentVariable("TB_Membros"))
        {
            
        }
    }
}