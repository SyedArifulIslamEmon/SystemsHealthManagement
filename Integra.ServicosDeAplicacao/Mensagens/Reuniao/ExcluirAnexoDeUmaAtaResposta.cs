using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class ExcluirAnexoDeUmaAtaResposta : RespostaBase
    {
        public Arquivo Anexo { get; set; }
    }
}