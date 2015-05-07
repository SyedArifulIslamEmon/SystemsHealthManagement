using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class HomeIndexViewModel
    {
        public IList<Modulo> Modulos { get; set; }
    }
}