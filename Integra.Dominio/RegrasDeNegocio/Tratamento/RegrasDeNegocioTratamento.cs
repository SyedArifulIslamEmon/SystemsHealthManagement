using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Tratamento
{
    public static class RegrasDeNegocioTratamento
    {
        public static RegraDeNegocioBase DeveTerUmPrograma { get { return new RegraDeNegocioTratamentoDeveTerUmPrograma(); } }
    }
}
