using System;
using System.Collections.Generic;
using System.Linq;
using Integra.Dominio;
using Integra.Web.Models;

namespace Integra.Web.Helpers
{
    public static class PessoaExtension
    {
        public static PessoaViewModel ToViewModel(this Pessoa pessoa)
        {
            var listaPrograma = pessoa.ProgramasPermitidos.Select(programa => programa.Nome + ',');
            string concat = String.Join(String.Empty, listaPrograma.ToArray());
            return new PessoaViewModel
                       {
                           Codigo = pessoa.Codigo,
                           Nome = pessoa.Nome,
                           Telefone = pessoa.Telefone,
                           NomeDeUsuario = pessoa.Usuario.NomeDeUsuario,
                           Grupo = pessoa.Usuario.Perfil.Grupo.Descricao,
                           Perfil = pessoa.Usuario.Perfil.Nome,
                           Status = pessoa.Inativo ? "Inativo" : "Ativo",
                           Programas = concat
                       };
        }
        public static IList<PessoaViewModel> ToViewModel(this IList<Pessoa> pessoas)
        {
            return pessoas.Select(ToViewModel).ToList();
        }
    }
}