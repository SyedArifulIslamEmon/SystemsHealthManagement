using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Reuniao
{
    public static class RegrasDeNegocioReuniao
    {
        public static RegraDeNegocioBase RequerUmPrograma { get { return new RegraDeNegocioReuniaoRequerUmPrograma(); } }
    }
}