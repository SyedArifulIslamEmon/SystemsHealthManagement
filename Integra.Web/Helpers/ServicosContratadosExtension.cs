using Integra.Dominio;
using Integra.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Integra.Web.Helpers
{
    public static class ServicosContratadosExtension
    {
        public static ServicosContratadosViewModel ToViewModel(this ServicosContratados servicosContratados)
        {
            return new ServicosContratadosViewModel
            {                
                Codigo = servicosContratados.Codigo,
                Nome = servicosContratados.Nome,
                Descricao = servicosContratados.Descricao,
                Quantidade = servicosContratados.Quantidade,
                Observacoes = servicosContratados.Observacoes,
                DataContratacao = servicosContratados.DataContratacao            
            };
        }

        public static IList<ServicosContratadosViewModel> ToViewModel(this IList<ServicosContratados> servicosContratados)
        {
            return servicosContratados.Select(ToViewModel).ToList();
        }
    }
}