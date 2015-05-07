using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AlterarDocumentoStatusResposta : RespostaBase
    {
        public ClinicaDocumentos Documento { get; set; }

    }
}
