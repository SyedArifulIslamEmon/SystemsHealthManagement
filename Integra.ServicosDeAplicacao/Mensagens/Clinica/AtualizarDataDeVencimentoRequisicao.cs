using System;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AtualizarDataDeVencimentoRequisicao
    {
        public int CodigoDaClinica { get; set; }

        public int CodigoDoDocumento { get; set; }

        public DateTime DataDeVencimento { get; set; }
    }
}