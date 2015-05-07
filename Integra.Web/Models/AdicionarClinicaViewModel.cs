using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarClinicaViewModel
    {
        public int Codigo { get; set; }
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
        public string Observacoes { get; set; }

        public StatusDaClinica Status { get; set; }
        public dynamic ListaDeStatus { get; set; }

        public string Email { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public bool IndicaNovosPacientes { get; set; }
        public int CodigoDoRepresentante { get; set; }
        public int CodigoDoRepresentanteRegional { get; set; }
        public int CodigoDoGerente { get; set; }

        public IList<RepresentanteRegional> RepresentantesRegionais { get; set; }

        public IList<Representante> Representantes { get; set; }

        public IList<Gerente> Gerentes { get; set; }

        public decimal ValorInfusao { get; set; }

        public string Bairro { get; set; }
    }
}