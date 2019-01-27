using sipsa.Dominio.Membros;

namespace sipsa.Dados.Repositorios
{
    public class TelefoneRepositorio : _RepositorioBase<Telefone>, ITelefoneRepositorio
    {
        public TelefoneRepositorio(SipsaContexto contexto)
        : base(contexto)
        {
            
        }
    }
}