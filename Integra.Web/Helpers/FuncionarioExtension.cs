using System.Collections.Generic;
using System.Linq;
using Integra.Dominio;
using Integra.Web.Models;

namespace Integra.Web.Helpers
{
    public static class FuncionarioExtension
    {
        public static FuncionarioViewModel ToViewModel(this Funcionario funcionario)
        {
            return new FuncionarioViewModel
                       {
                           Codigo = funcionario.Codigo,
                           Nome = funcionario.Nome,
                           Cargo = funcionario.Cargo.Descricao,
                           DescricaoDoCargo = funcionario.Descricao
                       };
        }

        public static IList<FuncionarioViewModel> ToViewModel(this IList<Funcionario> funcionarios)
        {
            return funcionarios.Select(ToViewModel).ToList();
        }
    }
}