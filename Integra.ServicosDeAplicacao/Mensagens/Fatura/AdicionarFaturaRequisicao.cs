using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Fatura
{
    public class AdicionarFaturaRequisicao
    {
        public string Descricao { get; set; }

        public TipoDaFatura Tipo { get; set; }

        public StatusDaFatura Status { get; set; }

        public TipoDeDocumento TipoDoDocumento { get; set; }

        public decimal Valor { get; set; }

        public string NumeroDoDocumento { get; set; }

        public DateTime Data { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}