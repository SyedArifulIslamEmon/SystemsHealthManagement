namespace Integra.Web.Models
{
    public class AnaliseDeSolicitacaoViewModel
    {
        public int Codigo { get; set; }
        public decimal Custo { get; set; }
        public int DiasParaEntrega { get; set; }
        public string Atividade { get; set; }
        public string Analise { get; set; }
        public bool AprovacaoDoCliente { get; set; }
    }
}