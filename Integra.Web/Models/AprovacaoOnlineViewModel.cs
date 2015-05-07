using System.Collections.Generic;
using System.Web;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AprovacaoOnlineViewModel
    {
        public IList<AprovacaoViewModel> Escopos { get; set; }
        public IList<AprovacaoViewModel> Scripts { get; set; }
        public IList<AprovacaoViewModel> Mudancas { get; set; }
        public IList<AprovacaoViewModel> Materiais { get; set; }
        public IList<AprovacaoViewModel> Internos { get; set; }

        public HttpPostedFileBase Arquivo { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public TipoDaAprovacao Tipo { get; set; }
    }
}