using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Aprovacao
{
    public class ObterArquivoDaAprovacaoResposta : RespostaBase
    {
        public FileStream Arquivo { get; set; }
        public Arquivo Anexo { get; set; }
    }
}