using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AlterarClinicaRequisicao
    {
        public int CodigoDaClinica { get; set; }
        public int CodigoDoResponsavel { get; set; }

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public int CodigoDoRepresentante { get; set; }
        public int CodigoDoRepresentanteRegional { get; set; }
        public int CodigoDoGerente { get; set; }
        public string Observacoes { get; set; }

        public StatusDaClinica Status { get; set; }

        public string Email { get; set; }

        public bool IndicaNovosPacientes { get; set; }

        public string Telefone2 { get; set; }

        public string Telefone3 { get; set; }

        public decimal ValorDeInfusao { get; set; }

        public string Bairro { get; set; }
    }
}