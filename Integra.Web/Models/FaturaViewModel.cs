using System;

namespace Integra.Web.Models
{
    public class FaturaViewModel
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Documento { get; set; }
        public string MesDeReferencia { get; set; }
        public string NumeroDoDocumento { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
    }
}