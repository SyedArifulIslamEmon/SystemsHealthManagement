using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Treinamento
{
    public class ObterAnexoDoTreinamentoResposta : RespostaBase
    {
        public FileStream Arquivo { get; set; }

        public Arquivo Anexo { get; set; }
    }
}