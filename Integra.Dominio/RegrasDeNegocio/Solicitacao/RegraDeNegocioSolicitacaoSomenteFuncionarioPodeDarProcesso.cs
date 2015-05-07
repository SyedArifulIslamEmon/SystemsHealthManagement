using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoSomenteFuncionarioPodeDarProcesso : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoSomenteFuncionarioPodeDarProcesso() : base("Somente um funcionário pode realizar o processo da solicitação.")
        {
        }
    }
}