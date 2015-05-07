using System.Collections.Generic;
using System.Transactions;

namespace Integra.Dominio.Base.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly Dictionary<IRaizDeAgregacao, IUnitOfWorkRepository> _entidadesAdicionadas;
        private readonly Dictionary<IRaizDeAgregacao, IUnitOfWorkRepository> _entidadesAlteradas;
        private readonly Dictionary<IRaizDeAgregacao, IUnitOfWorkRepository> _entidadesDeletadas;
        public UnitOfWork()
        {
            _entidadesAdicionadas = new Dictionary<IRaizDeAgregacao, IUnitOfWorkRepository>();
            _entidadesAlteradas = new Dictionary<IRaizDeAgregacao, IUnitOfWorkRepository>();
            _entidadesDeletadas = new Dictionary<IRaizDeAgregacao, IUnitOfWorkRepository>();
        }

        public void RegistroAlterado(IRaizDeAgregacao entidade,
        IUnitOfWorkRepository unitofWorkRepositorio)
        {
            if (!_entidadesAlteradas.ContainsKey(entidade))
            {
                _entidadesAlteradas.Add(entidade, unitofWorkRepositorio);
            }
        }

        public void RegistroAdicionado(IRaizDeAgregacao entidade,
        IUnitOfWorkRepository unitofWorkRepositorio)
        {
            if (!_entidadesAdicionadas.ContainsKey(entidade))
            {
                _entidadesAdicionadas.Add(entidade, unitofWorkRepositorio);
            }
        }

        public void RegistroRemovido(IRaizDeAgregacao entidade,
        IUnitOfWorkRepository unitofWorkRepositorio)
        {
            if (!_entidadesDeletadas.ContainsKey(entidade))
            {
                _entidadesDeletadas.Add(entidade, unitofWorkRepositorio);
            }
        }

        public void Commit()
        {
            using (var scope = new TransactionScope())
            {
                foreach (IRaizDeAgregacao entidade in _entidadesAdicionadas.Keys)
                {
                    _entidadesAdicionadas[entidade].PersistirA(entidade);
                }
                foreach (IRaizDeAgregacao entidade in _entidadesAlteradas.Keys)
                {
                    _entidadesAlteradas[entidade].PersistirAtualizacaoDa(entidade);
                }
                foreach (IRaizDeAgregacao entidade in _entidadesDeletadas.Keys)
                {
                    _entidadesDeletadas[entidade].PersistirDelecaoDa(entidade);
                }
                scope.Complete();
            }
        }
    }
}