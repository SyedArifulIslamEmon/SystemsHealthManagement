using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoDeveEstarComSituacaoParaAprovacao : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoDeveEstarComSituacaoParaAprovacao()
            : base("A solicita��o s� pode ser aprovada se a situa��o for 'Em aprova��o'!")
        {
        }
    }
}