using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AlterarAtaEmUmaReuniaoResposta: RespostaBase
    {
        public Ata Ata { get; set; }
    }
}