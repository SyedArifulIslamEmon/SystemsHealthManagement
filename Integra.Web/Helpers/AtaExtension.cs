using System.Collections.Generic;
using Integra.Dominio;
using Integra.Web.Models;
using System.Linq;
using Integra.Dominio.Base;

namespace Integra.Web.Helpers
{
    public static class AtaExtension
    {
        public static AtaViewModel ToViewModel(this Ata ata)
        {
            return new AtaViewModel
                       {
                           Codigo = ata.Codigo,
                           Anotacoes = ata.Anotacoes,
                           Assunto = ata.Assunto,
                           FinalDoPrazo = ata.FinalDoPrazo,
                           InicioDoPrazo = ata.InicioDoPrazo,
                           Status = ata.Status.GetStringValue(),
                           CodigoDoStatus = ata.Status,
                           Responsavel = ata.Responsavel.ToViewModel()
                       };
        }

        public static IList<AtaViewModel> ToViewModel(this IList<Ata> atas)
        {
            return atas.Select(ToViewModel).ToList();
        }
    }
}