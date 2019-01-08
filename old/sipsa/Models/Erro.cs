namespace sipsa.Models
{
    public class Erro
    {
        public string RequisicaoId { get; set; }

        public bool MostrarRequisicaoId => !string.IsNullOrEmpty(RequisicaoId);
    }

}
