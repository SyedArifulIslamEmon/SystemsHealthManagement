using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.ServicosContratados
{
    public class RegrasDeNegocioServicosContratadosDeveTerUmPrograma : RegraDeNegocioBase
    {
        public RegrasDeNegocioServicosContratadosDeveTerUmPrograma() : base("Um serviço deve ter um programa associado.")
        {
        }
    }
}
