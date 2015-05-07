using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base;
using System.Linq;
using Integra.Web.Models;

namespace Integra.Web.Helpers
{
    public static class InfusaoExtension
    {
         public static InfusaoViewModel ToViewModel(this Infusao infusao)
         {
             return new InfusaoViewModel
                        {
                            Cpf = infusao.Cpf,
                            DataCadastro = infusao.DataCadastro,
                            DataInfusao = infusao.DataInfusao,
                            Localizador = infusao.Localizador,
                            Responsavel = infusao.Responsavel.Codigo,
                            Status = infusao.StatusDaInfusao.GetStringValue(),
                            Codigo = infusao.Codigo,
                            Valor = infusao.Clinica.ValorDeInfusao,
                            CodigoClinica = infusao.Clinica.Codigo,
                            Multa = infusao.Multa(),
                            NomePaciente = !string.IsNullOrEmpty(infusao.NomePaciente) ? (infusao.NomePaciente.Split('|').Length - 1 > 0 ? infusao.NomePaciente.Split('|')[0] : infusao.NomePaciente) : "",
                            Dosagem = !string.IsNullOrEmpty(infusao.Dosagem) ? infusao.Dosagem : "",
                            Ampola = !string.IsNullOrEmpty(infusao.Ampola) ? infusao.Ampola : "",
                            Lote = !string.IsNullOrEmpty(infusao.Lote) ? infusao.Lote : ""
                        };
         }

        public static List<InfusaoViewModel> ToViewModel(this IList<Infusao> infusaos)
        {
            return infusaos.Select(ToViewModel).ToList();
        } 
    }
}