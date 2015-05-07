using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Faturamento
{
    public class ObterComprovanteResposta : RespostaBase
    {
        public NotaFiscal Nota { get; set; }

        public FileStream Arquivo { get; set; }
    }
}