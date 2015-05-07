

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AlterarDocumentoStatusRequisicao
    {
        public int CodigoDaClinica { get; set; }
        public int CodigoDoDocumento { get; set; }
        public string Status { get; set; }
    }
}
