using System.Collections.Generic;
using System.Web;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarAnexoReuniaoViewModel
    {
        public List<Arquivo> Anexos { get; set; }
        public int CodigoDaReuniao { get; set; }
        public string Descricao { get; set; }
        public HttpPostedFileBase Arquivo { get; set; }
    }
}