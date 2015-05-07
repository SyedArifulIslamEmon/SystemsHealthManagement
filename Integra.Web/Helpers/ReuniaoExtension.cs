using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Web.Models;
using System.Linq;

namespace Integra.Web.Helpers
{
    public static class ReuniaoExtension
    {
        public static ReuniaoViewModel ToViewModel(this Reuniao reuniao)
        {
            return new ReuniaoViewModel
                       {
                           Realizacao = reuniao.Realizacao,
                           Programa = reuniao.Programa.Nome,
                           Participantes = reuniao.Participantes.ToViewModel(),
                           Responsavel = reuniao.Responsavel.ToViewModel(),
                           Local = reuniao.Local,
                           Status = reuniao.Status.GetStringValue(),
                           Assunto = reuniao.Assunto,
                           Codigo = reuniao.Codigo
                       };
        }

        public static IList<ReuniaoViewModel> ToViewModel(this IList<Reuniao> reunioes)
        {
            return reunioes.Select(ToViewModel).ToList();
        }
    }
}