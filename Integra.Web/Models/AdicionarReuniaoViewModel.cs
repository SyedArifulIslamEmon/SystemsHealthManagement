using System;
using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarReuniaoViewModel
    {
        public IList<FuncionarioViewModel> Funcionarios { get; set; }
        public dynamic ListaDeStatus { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public string Local { get; set; }
        public string Assunto { get; set; }
        public DateTime Realizacao { get; set; }
        public StatusDaReunicao Status { get; set; }
        public int Codigo { get; set; }
    }
}