using System.Collections.Generic;
using System.Linq;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Web.Models;

namespace Integra.Web.Helpers
{
    public static class ClinicaExtension
    {
        public static ClinicaViewModel ToViewModel(this Clinica clinica)
        {
            return new ClinicaViewModel
            {
                Codigo = clinica.Codigo,
                Programa = clinica.Programa.Nome,
                Responsavel = clinica.Responsavel.ToViewModel(),
                Nome = clinica.Nome,
                RazaoSocial = clinica.RazaoSocial,
                Cnpj = clinica.Cnpj,
                InscricaoEstadual = clinica.InscricaoEstadual,
                Endereco = clinica.Endereco,
                Cidade = clinica.Cidade,
                Uf = clinica.Uf,
                Telefone = clinica.Telefone,
                Contato = clinica.Contato,
                Representante = clinica.Representante != null ? clinica.Representante.Nome : string.Empty,
                Gerente = clinica.Gerente != null ? clinica.Gerente.Nome : string.Empty,
                RepresentanteRegional = clinica.RepresentanteRegional != null ? clinica.RepresentanteRegional.Nome : string.Empty,
                Observacoes = clinica.Observacoes,
                Email = clinica.Email,
                DataCadastro = clinica.DataCadastro,
                Status = clinica.Status.GetStringValue()
            };
        }
        public static List<ClinicaViewModel> ToViewModel(this List<Clinica> clinicas)
        {
            return clinicas.Select(ToViewModel).ToList();
        }
    }
}