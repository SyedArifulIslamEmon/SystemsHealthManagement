using System.Collections.Generic;
using System.Linq;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Web.Models;

namespace Integra.Web.Helpers
{
    public static class AprovacaoExtension
    {
        public static AprovacaoViewModel ToViewModel(this Aprovacao aprovacao)
        {
            return new AprovacaoViewModel
                       {
                           Codigo = aprovacao.Codigo,
                           DataDaAprovacao = aprovacao.DataDaAprovacao,
                           Grupo = aprovacao.GrupoResponsavel != null ? aprovacao.GrupoResponsavel.Nome : null,
                           Descricao = aprovacao.Anexo.Descricao,
                           DataDeUpload = aprovacao.Anexo.DataDeUpload,
                           Titulo = aprovacao.Titulo,
                           Responsavel = aprovacao.ResponsavelPelaAprovacao != null ? aprovacao.ResponsavelPelaAprovacao.Nome : null,
                           Status = aprovacao.Status.GetStringValue(),
                           Tipo = aprovacao.Tipo,
                           Programa = aprovacao.Programa 
                       };
        }

        public static IList<AprovacaoViewModel> ToViewModel(this IList<Aprovacao> aprovacoes)
        {
            return aprovacoes.Select(ToViewModel).ToList();
        }
    }
}