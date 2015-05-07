using System;

namespace Integra.Web.Models
{
    public class InfusaoViewModel
    {
        public string Cpf { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataInfusao { get; set; }

        public string Localizador { get; set; }

        public int Responsavel { get; set; }

        public string Status { get; set; }

        public int CodigoClinica { get; set; }

        public int Codigo { get; set; }

        public decimal Valor { get; set; }

        public decimal Multa { get; set; }

        public int CodigoNotaFiscal { get; set; }

        public virtual string NomePaciente { get; set; }

        public virtual string Dosagem { get; set; }

        public virtual string Ampola { get; set; }

        public virtual string Lote { get; set; }
    }
}