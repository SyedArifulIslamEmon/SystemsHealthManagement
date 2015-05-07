using System;
using System.Collections.Generic;
using System.IO;

namespace Integra.ServicosDeAplicacao.Mensagens.Faturamento
{
    public class NovaNotaRequisicao
    {
        public NovaNotaRequisicao()
        {
            Infusoes = new List<AssociarInfusao>();
        }
        public int CodigoDaClinica { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public decimal Valor { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string DescricaoDoArquivo { get; set; }
        public string NomeDoArquivo { get; set; }
        public Stream Arquivo { get; set; }
        public List<AssociarInfusao> Infusoes { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}