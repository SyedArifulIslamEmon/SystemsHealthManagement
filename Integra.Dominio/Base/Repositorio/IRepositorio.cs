using System.Collections.Generic;

namespace Integra.Dominio.Base.Repositorio
{
    public interface IRepositorio<T, in TId> where T : class
    {
        void Adicionar(T entidade);
        void Remover(T entidade);
        void Atualizar(T entidade);

        T ObterPor(TId codigo);
        IList<T> ObterTodos();
    }
}