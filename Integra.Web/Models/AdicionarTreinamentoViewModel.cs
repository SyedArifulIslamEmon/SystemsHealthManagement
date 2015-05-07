using System;
using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class AdicionarTreinamentoViewModel
    {
        public int Codigo { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string Local { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public IList<FuncionarioViewModel> Funcionarios { get; set; }
    }
}