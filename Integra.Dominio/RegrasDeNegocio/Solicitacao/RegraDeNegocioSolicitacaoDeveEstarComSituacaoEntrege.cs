using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoDeveEstarComSituacaoEntrege : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoDeveEstarComSituacaoEntrege()
            : base("A solicitação só pode ser entrege se a situação for 'Entrege'!")
        {
        }
    }
}