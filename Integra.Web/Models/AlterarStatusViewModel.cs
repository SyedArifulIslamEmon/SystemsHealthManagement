using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AlterarStatusViewModel
    {
        public StatusDaClinica NovoStatus { get; set; }
        public string Observacao { get; set; }
        public int CodigoDaClinica { get; set; }
    }
}