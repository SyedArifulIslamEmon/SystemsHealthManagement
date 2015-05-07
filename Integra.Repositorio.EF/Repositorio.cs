using System.Collections.Generic;
using System.Linq;
using Integra.Dominio.Base.UoW;

namespace Integra.Repositorio.EF
{
    public abstract class Repositorio<T, TEntidadeChave> : IUnitOfWorkRepository where T : IRaizDeAgregacao
    {
        private readonly IUnitOfWork _uow;

        public Repositorio(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Adicionar(T entidade)
        {
            _uow.RegistroAdicionado(entidade, this);
        }

        public void Remover(T entidade)
        {
            _uow.RegistroRemovido(entidade, this);
        }

        public void Atualizar(T entidade)
        {
            // _uow.RegistroAlterado(entidade, this);
        }

        public IQueryable<T> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().Set(typeof(T)) as IQueryable<T>;
        }

        public abstract T ObterPor(TEntidadeChave codigo);

        public IList<T> ObterTodos()
        {
            return GetObjectSet().ToList();
        }

        public List<T> ObterTodos(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList();
        }

        public void PersistirA(IRaizDeAgregacao entidade)
        {
            DataContextFactory.GetDataContext().Set(entidade.GetType()).Add(entidade);
        }

        public void PersistirAtualizacaoDa(IRaizDeAgregacao entidade)
        {
            // Do nothing as EF tracks changes
        }

        public void PersistirDelecaoDa(IRaizDeAgregacao entidade)
        {
            DataContextFactory.GetDataContext().Set(entidade.GetType()).Remove(entidade);
        }
    }
}