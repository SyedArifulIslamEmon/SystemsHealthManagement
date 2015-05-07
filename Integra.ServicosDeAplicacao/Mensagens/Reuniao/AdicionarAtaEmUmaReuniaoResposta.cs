using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarAtaEmUmaReuniaoResposta : RespostaBase
    {
        public Ata Ata { get; set; }
    }
}