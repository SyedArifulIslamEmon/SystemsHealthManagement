using System.Collections.Generic;
using System.Web;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarAnexoAtaReuniaoViewModel
    {
        public string Descricao { get; set; }
        public HttpPostedFile Arquivo { get; set; }
        public int CodigoDaReuniao { get; set; }
        public int CodigoDaAta { get; set; }

        public List<Arquivo> Anexos { get; set; }
    }
}