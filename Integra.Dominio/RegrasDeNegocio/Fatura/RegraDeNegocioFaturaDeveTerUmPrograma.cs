using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Fatura
{
    public class RegraDeNegocioFaturaDeveTerUmPrograma : RegraDeNegocioBase
    {
        public RegraDeNegocioFaturaDeveTerUmPrograma() : base("Uma fatura deve ter um programa associado.")
        {
        }
    }
}