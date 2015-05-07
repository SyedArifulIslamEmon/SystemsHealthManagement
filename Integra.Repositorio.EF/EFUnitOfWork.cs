using Integra.Dominio.Base.UoW;

namespace Integra.Repositorio.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public void RegistroAlterado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio)
        {
            unitofWorkRepositorio.PersistirAtualizacaoDa(entidade);
        }

        public void RegistroAdicionado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio)
        {
            unitofWorkRepositorio.PersistirA(entidade);
        }

        public void RegistroRemovido(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio)
        {
            unitofWorkRepositorio.PersistirDelecaoDa(entidade);
        }

        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }
    }
}