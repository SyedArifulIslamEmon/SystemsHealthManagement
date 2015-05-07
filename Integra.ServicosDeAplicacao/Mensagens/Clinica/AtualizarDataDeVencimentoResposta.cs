using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AtualizarDataDeVencimentoResposta : RespostaBase
    {
        public DateTime DataVencimento { get; set; }
        public ClinicaDocumentos Documento { get; set; }
    }
}