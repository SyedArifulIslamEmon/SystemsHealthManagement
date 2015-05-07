using System;
using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class TratamentoViewModel
    {
        public int Codigo { get; set; }
        public string Programa { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public string Ifx { get; set; }
        public string Medico { get; set; }
        public string Representante { get; set; }
        public string MotivoSolicitacao { get; set; }
        public string Status { get; set; }
        public DateTime? DataStatus { get; set; }
        public string Observacoes { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public string Grupo { get; set; }

        public string Responsavel { get; set; }
        public IList<FuncionarioViewModel> Funcionarios { get; set; }
    }
}