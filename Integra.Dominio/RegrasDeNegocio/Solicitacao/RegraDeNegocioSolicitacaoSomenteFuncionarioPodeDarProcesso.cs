using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoSomenteFuncionarioPodeDarProcesso : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoSomenteFuncionarioPodeDarProcesso() : base("Somente um funcion�rio pode realizar o processo da solicita��o.")
        {
        }
    }
}