using System;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AprovacaoViewModel
    {
        public int Codigo { get; set; }
        public DateTime? DataDaAprovacao { get; set; }
        public string Grupo { get; set; }
        public string Responsavel { get; set; }
        public string Status { get; set; }
        public TipoDaAprovacao Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeUpload { get; set; }
        public string Titulo { get; set; }
        public Programa Programa { get; set; }
    }
}