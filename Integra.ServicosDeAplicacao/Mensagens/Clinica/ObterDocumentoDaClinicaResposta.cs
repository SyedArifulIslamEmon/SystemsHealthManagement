using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class ObterDocumentoDaClinicaResposta : RespostaBase
    {
        public FileStream Arquivo { get; set; }
        public ClinicaDocumentos Documento { get; set; }
    }
}