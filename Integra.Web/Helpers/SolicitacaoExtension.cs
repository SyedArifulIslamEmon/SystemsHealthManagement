using System.Collections.Generic;
using Integra.Dominio;
using Integra.Web.Models;
using System.Linq;
using Integra.Dominio.Base;

namespace Integra.Web.Helpers
{
    public static class SolicitacaoExtension
    {
        public static SolicitacaoViewModel ToViewModel(this Solicitacao solicitacao)
        {
            var viewModel = new SolicitacaoViewModel
                                {
                                    Protocolo = solicitacao.Abertura.Protocolo,
                                    DataDeAbertura = solicitacao.Abertura.DataDaAbertura,
                                    Situacao = solicitacao.Situacao.GetStringValue(),
                                    SituacaoCodigo = solicitacao.Situacao,
                                    Codigo = solicitacao.Codigo,
                                    DiasSLA = solicitacao.Abertura.Tipo.SLA,
                                    Solicitante = solicitacao.Abertura.Responsavel.Nome,
                                    Tipo = solicitacao.Abertura.Tipo.Descricao,
                                    Programa = solicitacao.Abertura.Programa 
                                };
            return viewModel;
        }

        public static IList<SolicitacaoViewModel> ToViewModel(this IList<Solicitacao> solicitacao)
        {
            return solicitacao.Select(ToViewModel).ToList();
        }
    }
}