using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioPessoaDoGrupoIntegraDeveTerUmDepartamento : RegraDeNegocioBase
    {
        public RegraDeNegocioPessoaDoGrupoIntegraDeveTerUmDepartamento() : base("Uma pessoa do grupo integra deve conter um departamento!")
        {
        }
    }
}