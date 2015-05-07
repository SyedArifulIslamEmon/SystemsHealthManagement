using System.Collections.Generic;
using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IFaturaRepositorio : IRepositorio<Fatura, int>
    {
        List<Fatura> ObterTodos(Programa programa);
    }
}