using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioPessoaDevePertencerAoGrupoIntegraParaTerUmDepartamento : RegraDeNegocioBase
    {
        public RegraDeNegocioPessoaDevePertencerAoGrupoIntegraParaTerUmDepartamento()
            : base("Uma pessoa só pode ter departamento se pertencer ao grupo 'Integra'")
        {
        }
    }
}