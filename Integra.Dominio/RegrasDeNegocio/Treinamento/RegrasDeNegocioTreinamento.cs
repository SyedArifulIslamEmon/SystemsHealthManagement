using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Treinamento
{
    public static class RegrasDeNegocioTreinamento
    {
        public static RegraDeNegocioBase DeveTerUmPrograma { get { return new RegraDeNegocioTreinamentoDeveTerUmPrograma(); } }
    }
}
