using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Infusao
{
    public class CancelarInfusaoRequisicao
    {
        public int CodigoDaClinica { get; set; }
        public string Localizador { get; set; }
        public string Cpf { get; set; }
        public StatusDaInfusao StatusDaInfusao { get; set; }
    }
}
