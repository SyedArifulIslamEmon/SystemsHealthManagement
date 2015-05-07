namespace Integra.Dominio.Base.UoW
{
    public interface IUnitOfWork
    {
        void RegistroAlterado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio);
        void RegistroAdicionado(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio);
        void RegistroRemovido(IRaizDeAgregacao entidade, IUnitOfWorkRepository unitofWorkRepositorio);
        void Commit();
    }
}