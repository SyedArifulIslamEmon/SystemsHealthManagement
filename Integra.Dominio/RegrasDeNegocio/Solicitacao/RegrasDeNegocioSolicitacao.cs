using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public static class RegrasDeNegocioSolicitacao
    {
        public static RegraDeNegocioBase DeveEstarComSituacaoEmAnalise { get { return new RegraDeNegocioSolicitacaoDeveEstarComSituacaoEmAnalise(); } }

        public static RegraDeNegocioBase DeveEstarComSituacaoParaAprovacao { get { return new RegraDeNegocioSolicitacaoDeveEstarComSituacaoParaAprovacao(); } }

        public static RegraDeNegocioBase DeveEstarComSituacaoEmProcesso { get { return new RegraDeNegocioSolicitacaoDeveEstarComSituacaoEmProcesso(); } }

        public static RegraDeNegocioBase DeveEstarComSituacaoEntrege { get { return new RegraDeNegocioSolicitacaoDeveEstarComSituacaoEntrege(); } }

        public static RegraDeNegocioBase SomenteUmFuncionaroPodeAnalisar { get { return new RegraDeNegocioSolicitacaoSomenteUmFuncionaroPodeAnalisar(); } }

        public static RegraDeNegocioBase SomenteUmClientePodeAprovar { get { return new RegraDeNegocioSolicitacaoSomenteUmClientePodeAprovar(); } }

        public static RegraDeNegocioBase SomenteFuncionarioPodeDarProcesso { get { return new RegraDeNegocioSolicitacaoSomenteFuncionarioPodeDarProcesso(); } }

        public static RegraDeNegocioBase SomenteClientePodeAceitarEntrega { get { return new RegraDeNegocioSolicitacaoSomenteClientePodeAceitarEntrega(); } }
    }
}