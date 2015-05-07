using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Treinamento
{
    public class RegraDeNegocioTreinamentoDeveTerUmPrograma : RegraDeNegocioBase
    {
        public RegraDeNegocioTreinamentoDeveTerUmPrograma()
            : base("Um treinamento deve ter um program.")
        {
        }
    }
}