using Integra.Dominio.Base.Repositorio;
using System.Collections.Generic;

namespace Integra.Dominio.Repositorios
{
    public interface ITratamentoRepositorio : IRepositorio<Tratamento, int>
    {
        List<Tratamento> ObterTodos(Programa programa);
    }
}
