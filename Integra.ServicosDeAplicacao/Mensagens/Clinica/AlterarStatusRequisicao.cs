using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AlterarStatusRequisicao
    {
        public int CodigoDaClinica { get; set; }

        public string Observacao { get; set; }

        public StatusDaClinica NovoStatus { get; set; }
    }
}