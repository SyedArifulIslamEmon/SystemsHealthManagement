using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Web.Models;
using System.Linq;

namespace Integra.Web.Helpers
{
    public static class TratamentoExtension
    {
        public static TratamentoViewModel ToViewModel(this Tratamento tratamento)
        {
            return new TratamentoViewModel
            {
                Codigo = tratamento.Codigo,
                DataSolicitacao = tratamento.DataSolicitacao,
                Ifx = tratamento.Ifx,
                Medico = tratamento.Medico,
                Representante = tratamento.Representante,
                MotivoSolicitacao = tratamento.MotivoSolicitacao,
                Responsavel = tratamento.Responsavel != null ? tratamento.Responsavel.Nome : null,
                Status = tratamento.Status.GetStringValue(),
                DataStatus = tratamento.DataStatus,
                Observacoes = tratamento.Observacoes,
                Programa = tratamento.Programa.Nome,
                Grupo = tratamento.GrupoResponsavel != null ? tratamento.GrupoResponsavel.Nome : null
            };
        }

        public static IList<TratamentoViewModel> ToViewModel(this IList<Tratamento> tratamento)
        {
            return tratamento.Select(ToViewModel).ToList();
        }
    }
}