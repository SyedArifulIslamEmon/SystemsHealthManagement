using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoDeveEstarComSituacaoEntrege : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoDeveEstarComSituacaoEntrege()
            : base("A solicita��o s� pode ser entrege se a situa��o for 'Entrege'!")
        {
        }
    }
}