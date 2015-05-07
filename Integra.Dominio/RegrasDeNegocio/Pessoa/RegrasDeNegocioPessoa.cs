using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public static class RegrasDeNegocioPessoa
    {
        public static RegraDeNegocioBase DevePertencerAoGrupoIntegraParaTerUmDepartamento
        {
            get { return new RegraDeNegocioPessoaDevePertencerAoGrupoIntegraParaTerUmDepartamento(); }
        }

        public static RegraDeNegocioBase DoGrupoDeveConterUmDepartamento
        {
            get { return new RegraDeNegocioPessoaDoGrupoIntegraDeveTerUmDepartamento(); }
        }
        public static RegraDeNegocioBase DeveTerUmCargo { get { return new RegraDeNegocioFuncionarioDeveTerUmCargo(); } }

        public static RegraDeNegocioBase DeveTerUmPrograma
        { get { return new RegraDeNegocioFuncionarioDeveTerUmPrograma(); } }

        public static RegraDeNegocioBase NaoPodeInformarUmCrmVazio { get { return new RegraDeNegocioClienteNaoDeveInformarUmCrmVazio(); } }

        public static RegraDeNegocioBase EmailJaExiste { get { return new RegraDeNegocioPessoaEmailJahExiste(); } }
    }
}