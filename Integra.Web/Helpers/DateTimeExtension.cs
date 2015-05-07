using System;
using System.Collections.Generic;
using System.Globalization;

namespace Integra.Web.Helpers
{
    public static class DateTimeExtension
    {
        public static dynamic ObterTodosOsMeses(this DateTime dateTime)
        {
            var months = new List<dynamic>();
            for (var i = 1; i <= 12; i++)
            {
                months.Add(new { Codigo = i, Descricao = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i) });
            }
            return months;
        }

        public static dynamic ObterTodosOsMesesAno(this DateTime dateTime)
        {
            var months = new List<dynamic>();
            for (var i = 1; i <= 12; i++)
            {
                months.Add(new { Codigo = i, Descricao = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i) });
            }
            months.Add(new { Codigo = 13, Descricao = "Todos" });
            return months;
        }
    }
}