using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoSomenteUmFuncionaroPodeAnalisar : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoSomenteUmFuncionaroPodeAnalisar() : base("Uma solicita��o s� pode ser analisada por um funcionario da integra!")
        {
        }
    }
}