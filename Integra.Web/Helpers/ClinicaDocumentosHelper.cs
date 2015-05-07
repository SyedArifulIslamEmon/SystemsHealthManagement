using System.Collections.Generic;
using System.Linq;
using Integra.Dominio;
using Integra.Web.Models;
using Integra.Dominio.Base;

namespace Integra.Web.Helpers
{
    public static class ClinicaDocumentosHelper
    {
        public static ClinicaDocumentoViewModel ToViewModel(this ClinicaDocumentos clinicaDocumento)
        {
            return new ClinicaDocumentoViewModel
                       {
                           DataDeUpload = clinicaDocumento.DataDeUpload,
                           Descricao = clinicaDocumento.Descricao,
                           Codigo = clinicaDocumento.Codigo,
                           Nome = clinicaDocumento.Nome,
                           Responsavel = clinicaDocumento.Responsavel.Nome,
                           TipoDoDocumento = clinicaDocumento.TipoDocumento.GetStringValue(),
                           DataDeVencimento = clinicaDocumento.DataDeVencimento,
                           StatusDocumento = clinicaDocumento.StatusDocumento.GetStringValue()
                       };
        }

        public static IList<ClinicaDocumentoViewModel> ToViewModel(this IList<ClinicaDocumentos> lista)
        {
            return lista.Select(ToViewModel).ToList();
        }
    }
}