using System.Collections.Generic;
using System.Linq;
using Integra.Dominio;
using Integra.Web.Models;

namespace Integra.Web.Helpers
{
    public static  class EquipeExtesion
    {
        public static EquipeViewModel ToViewModel(this Equipe equipe)
        {
            if (equipe == null)
                return null;
            return new EquipeViewModel
                       {
                           Codigo = equipe.Codigo,
                           Programa = equipe.Programa.Nome,
                           Membros = equipe.MenbrosDaEquipe.ToViewModel()
                       };
        }
        public static List<EquipeViewModel> ToViewModel(this List<Equipe> equipes)
        {
            return equipes.Select(ToViewModel).ToList();
        }
    }
}