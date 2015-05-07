using System;

namespace Integra.Web.Models
{
    public class ClinicaViewModel
    {
        public int Codigo { get; set; }
        public string Programa { get; set; }
        public FuncionarioViewModel Responsavel { get; set; }

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Representante { get; set; }
        public string Gerente { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string RepresentanteRegional { get; set; }
    }
}