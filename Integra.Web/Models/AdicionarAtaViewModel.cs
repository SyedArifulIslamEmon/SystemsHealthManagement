using System;
using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarAtaViewModel
    {
        public int Codigo { get; set; }
        public int CodigoDaReuniao { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public string Assunto { get; set; }
        public StatusDaAta Status { get; set; }
        public DateTime InicioDoPrazo { get; set; }
        public DateTime FinalDoPrazo { get; set; }
        public string Anotacoes { get; set; }
        public IList<FuncionarioViewModel> Funcionarios { get; set; }
        public dynamic ListaDeStatusDaAta { get; set; }
        public AtaViewModel Ata { get; set; }
    }
}