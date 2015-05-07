using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Fatura
{
    public static class RegrasDeNegocioFatura
    {
        public static RegraDeNegocioBase DeveTerUmPrograma { get { return new RegraDeNegocioFaturaDeveTerUmPrograma(); } }
    }
}