using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Solicitacao
{
    public class RegraDeNegocioSolicitacaoSomenteUmClientePodeAprovar : RegraDeNegocioBase
    {
        public RegraDeNegocioSolicitacaoSomenteUmClientePodeAprovar() : base("Uma solicita��o s� pode ser aprovado por um cliente.")
        {
        }
    }
}