using System;
using System.Collections.Generic;
using Integra.Dominio;
using System.Linq;

namespace Integra.Web.Helpers
{
    public static class NotaFiscalHelper
    {
        public static NotaFiscalViewModel ToViewModel(this NotaFiscal nota)
        {
            return new NotaFiscalViewModel
                       {
                           TotalDeInfusoes = nota.Infusoes.Count,
                           Valor = nota.Valor,
                           DataDeRecebimento = nota.DataRecebimento,
                           Data = nota.Data,
                           Status = nota.Status(),
                           Numero = nota.Numero,
                           Codigo = nota.Codigo,
                           MotivoDevolucao = nota.Motivo,
                           Responsavel = nota.Responsavel.Nome,
                           FormaDevolucao = nota.TipoDeDevolucao,
                           DataCriacao = nota.DataCriacao,
                           NomeDaClinica = nota.Clinica.Nome,
                           CodigoDaClinica = nota.Clinica.Codigo
                       };
        }

        public static IList<NotaFiscalViewModel> ToViewModel(this IList<NotaFiscal> notas)
        {
            return notas.Select(ToViewModel).ToList();
        }
    }

    public class NotaFiscalViewModel
    {
        public int TotalDeInfusoes { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeRecebimento { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public string Numero { get; set; }
        public int Codigo { get; set; }
        public string MotivoDevolucao { get; set; }
        public string Responsavel { get; set; }
        public string FormaDevolucao { get; set; }

        public DateTime DataCriacao { get; set; }
        public string NomeDaClinica { get; set; }
        public int CodigoDaClinica { get; set; }
    }
}