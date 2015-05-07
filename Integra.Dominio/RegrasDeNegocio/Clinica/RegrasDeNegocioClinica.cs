using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Clinica
{
    public static class RegrasDeNegocioClinica
    {
        public static RegraDeNegocioBase DeveTerUmPrograma { get { return new RegraDeNegocioClinicaDeveTerUmPrograma(); } }
    }
}