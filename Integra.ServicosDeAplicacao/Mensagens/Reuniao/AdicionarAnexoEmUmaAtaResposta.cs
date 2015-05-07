using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarAnexoEmUmaAtaResposta: RespostaBase
    {
        public Arquivo Anexo { get; set; }
    }
}