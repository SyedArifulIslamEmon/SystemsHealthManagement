using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class ObterAnexoDeUmaAtaResposta:RespostaBase
    {
        public FileStream Arquivo { get; set; }
        public Arquivo Anexo { get; set; }
    }
}