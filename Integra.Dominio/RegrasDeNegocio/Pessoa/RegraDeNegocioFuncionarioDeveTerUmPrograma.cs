using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioFuncionarioDeveTerUmPrograma : RegraDeNegocioBase
    {
        public RegraDeNegocioFuncionarioDeveTerUmPrograma() : base("Um funcionario deve ter um programa!")
        {
        }
    }
}