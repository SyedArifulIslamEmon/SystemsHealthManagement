using System;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AtaViewModel
    {
        public int Codigo { get; set; }
        public string Anotacoes { get; set; }
        public string Assunto { get; set; }
        public DateTime FinalDoPrazo { get; set; }
        public DateTime InicioDoPrazo { get; set; }
        public string Status { get; set; }
        public StatusDaAta CodigoDoStatus { get; set; }
        public FuncionarioViewModel Responsavel { get; set; }
    }
}