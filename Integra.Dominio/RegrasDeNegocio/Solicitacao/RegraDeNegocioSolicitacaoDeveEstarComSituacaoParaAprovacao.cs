using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoDeveEstarComSituacaoParaAprovacao : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoDeveEstarComSituacaoParaAprovacao()
            : base("A solicitação só pode ser aprovada se a situação for 'Em aprovação'!")
        {
        }
    }
}