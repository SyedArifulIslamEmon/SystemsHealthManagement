using System.Collections.Generic;
using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IServicosContratadosRepositorio : IRepositorio<ServicosContratados, int>
    {
        List<ServicosContratados> ObterTodos(Programa programa);
    }
}
