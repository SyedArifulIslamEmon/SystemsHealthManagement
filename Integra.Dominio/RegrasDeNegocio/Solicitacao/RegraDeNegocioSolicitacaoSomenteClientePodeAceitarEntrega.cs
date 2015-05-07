using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoSomenteClientePodeAceitarEntrega : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoSomenteClientePodeAceitarEntrega() : base("Somente um cliente pode aceitar a entrega!")
        {
        }
    }
}