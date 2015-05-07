using System;
using System.Web.Services;
using Integra.Dominio;
using Integra.ServicosDeAplicacao.Mensagens.Infusao;

namespace Integra.WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod(Description = "Inserir Nova Infusão")]
        public bool AdicionarInfusao(int idClinica, string localizador, string cpf, DateTime dataInfusao, DateTime dataCadastro)
        {
            var requisicao = new AdicionarInfusaoRequisicao
                {
                    CodigoDaClinica = idClinica,
                    Localizador = localizador,
                    Cpf = cpf,
                    DataInfusao = dataInfusao,
                    DataCadastro = dataCadastro,
                    StatusDaInfusao = StatusDaInfusao.Pendente
                };

            var resposta = new ServicosDeAplicacao.InfusaoServicoDeAplicacao().AdicionarInfusao(requisicao);
            
            return resposta.Sucesso;
        }

        [WebMethod(Description = "Cancelar Infusão")]
        public bool CancelarInfusao(int idClinica, string localizador, string cpf)
        {
            var requisicao = new CancelarInfusaoRequisicao
            {
                StatusDaInfusao = StatusDaInfusao.Cancelado
            };

            var resposta = new ServicosDeAplicacao.InfusaoServicoDeAplicacao().CancelarInfusao(requisicao);

            return resposta.Sucesso;
        }
    }
}