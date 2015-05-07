using System;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarFaturaViewModel
    {
        public dynamic StatusDaFatura { get; set; }
        public dynamic TiposDaFatura { get; set; }
        public dynamic TiposDoDocumento { get; set; }

        public DateTime Data { get; set; }
        public StatusDaFatura Statu { get; set; }
        public TipoDaFatura Tipo { get; set; }
        public TipoDeDocumento TipoDoDocumento { get; set; }
        public string NumeroDoDocumento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int Codigo { get; set; }
    }
}