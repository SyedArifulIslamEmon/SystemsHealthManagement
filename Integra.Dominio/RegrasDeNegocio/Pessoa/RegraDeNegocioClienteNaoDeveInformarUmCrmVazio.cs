using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioClienteNaoDeveInformarUmCrmVazio : RegraDeNegocioBase
    {
        public RegraDeNegocioClienteNaoDeveInformarUmCrmVazio() : base("N�o pode ser informado um CRM vazio.")
        {
        }
    }
}