using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Infusao
{
    public class AdicionarInfusaoRequisicao
    {
        public int CodigoDaClinica { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public string Localizador { get; set; }
        public string Cpf { get; set; }
        public DateTime DataInfusao { get; set; }
        public DateTime DataCadastro { get; set; }
        public StatusDaInfusao StatusDaInfusao { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}
