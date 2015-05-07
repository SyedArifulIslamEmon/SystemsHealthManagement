using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoDeveEstarComSituacaoEmProcesso : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoDeveEstarComSituacaoEmProcesso()
            : base("A solicitação só pode ser colocada em processo se a situação for 'Em processo'!")
        {
        }
    }
}