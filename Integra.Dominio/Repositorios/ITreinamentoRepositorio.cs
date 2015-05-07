using Integra.Dominio.Base.Repositorio;
using System.Collections.Generic;

namespace Integra.Dominio.Repositorios
{
    public interface ITreinamentoRepositorio : IRepositorio<Treinamento, int>
    {
        List<Treinamento> ObterTodos(Programa programa);
        Arquivo ObterAnexoDoTreinamento(int codigoDoTreinamento, int codigoDoAnexo);
    }
}
