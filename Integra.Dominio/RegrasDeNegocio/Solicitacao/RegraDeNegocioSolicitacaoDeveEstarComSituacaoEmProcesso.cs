using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoDeveEstarComSituacaoEmProcesso : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoDeveEstarComSituacaoEmProcesso()
            : base("A solicita��o s� pode ser colocada em processo se a situa��o for 'Em processo'!")
        {
        }
    }
}