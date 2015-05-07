using System;
using System.Linq;
using Integra.Dominio.Base;

namespace Integra.Web.Helpers
{
    public static class EnunsExtension
    {
        public static dynamic ToViewModel(this Type enu)
        {
            return
                Enum.GetValues(enu).Cast<Enum>().Select(a => new { Codigo = a, Descricao = a.GetStringValue() }).OrderBy(a => a.Descricao);
        }
    }
}