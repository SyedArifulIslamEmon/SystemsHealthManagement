using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.TipoDeCrm
{
    public class RegraDeNegocioTipoDeCrmDeveConterUmaDescricao : RegraDeNegocioBase
    {
        public RegraDeNegocioTipoDeCrmDeveConterUmaDescricao() : base("Um tipo de crm deve conter uma descrição!")
        {
        }
    }
}