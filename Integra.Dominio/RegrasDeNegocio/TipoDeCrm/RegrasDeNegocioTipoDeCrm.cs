using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.TipoDeCrm
{
    public static class RegrasDeNegocioTipoDeCrm
    {
        public static RegraDeNegocioBase DeveConterUmaDescricao { get { return new RegraDeNegocioTipoDeCrmDeveConterUmaDescricao(); } }
    }
}