using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Faturamento
{
    public class ObterArquivoDaNotaFiscalResposta : RespostaBase
    {
        public FileStream Arquivo { get; set; }

        public NotaFiscal Nota { get; set; }
    }
}