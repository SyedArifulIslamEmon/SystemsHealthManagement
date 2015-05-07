using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Tratamento
{
    public class RegraDeNegocioTratamentoDeveTerUmPrograma : RegraDeNegocioBase
    {
        public RegraDeNegocioTratamentoDeveTerUmPrograma()
            : base("Um tratamento deve ter um programa.")
        {
        }
    }
}