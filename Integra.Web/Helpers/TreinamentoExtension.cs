using System.Collections.Generic;
using Integra.Dominio;
using Integra.Web.Models;
using System.Linq;

namespace Integra.Web.Helpers
{
    public static class TreinamentoExtension
    {
        public static TreinamentoViewModel ToViewModel(this Treinamento treinamento)
        {
            return new TreinamentoViewModel
            {
                Codigo = treinamento.Codigo,
                DataRealizacao = treinamento.DataRealizacao,
                Responsavel = treinamento.Responsavel.ToViewModel(),
                Local = treinamento.Local,
                Titulo = treinamento.Titulo,
                Descricao = treinamento.Descricao,
                Programa = treinamento.Programa.Nome  
            };
        }

        public static IList<TreinamentoViewModel> ToViewModel(this IList<Treinamento> treinamento)
        {
            return treinamento.Select(ToViewModel).ToList();
        }
    }
}