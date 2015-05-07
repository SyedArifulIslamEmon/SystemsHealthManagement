using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Web.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Integra.Web.Helpers
{
    public static class FaturaExtension
    {
        public static FaturaViewModel ToViewModel(this Fatura fatura)
        {
            return new FaturaViewModel
                       {
                           Descricao = fatura.Descricao,
                           Documento = fatura.Documento.GetStringValue(),
                           MesDeReferencia = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fatura.Data.Month).UpperCaseFirstChar(),
                           Data = fatura.Data,
                           NumeroDoDocumento = fatura.NumeroDoDocumento,
                           Status = fatura.Status.GetStringValue(),
                           Valor = fatura.Valor,
                           Tipo = fatura.Tipo.GetStringValue(),
                           Codigo = fatura.Codigo
                       };
        }

        public static IList<FaturaViewModel> ToViewModel(this IList<Fatura> faturas)
        {
            return faturas.Select(ToViewModel).ToList();
        }
    }
}