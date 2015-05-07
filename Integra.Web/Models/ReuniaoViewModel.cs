using System;
using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class ReuniaoViewModel
    {
        public DateTime Realizacao { get; set; }
        public string Programa { get; set; }
        public IList<PessoaViewModel> Participantes { get; set; }
        public FuncionarioViewModel Responsavel { get; set; }
        public string Local { get; set; }
        public string Status { get; set; }
        public string Assunto { get; set; }
        public int Codigo { get; set; }
    }
}