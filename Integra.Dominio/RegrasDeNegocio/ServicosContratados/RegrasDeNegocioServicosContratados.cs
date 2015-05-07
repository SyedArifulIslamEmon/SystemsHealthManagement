using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.ServicosContratados
{
    public static class RegrasDeNegocioServicosContratados
    {
        public static RegraDeNegocioBase DeveTerUmPrograma { get { return new RegrasDeNegocioServicosContratadosDeveTerUmPrograma(); } }
    }
}
