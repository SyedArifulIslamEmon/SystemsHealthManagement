namespace Integra.Dominio.Base.UoW
{
    public interface IUnitOfWorkRepository
    {
        void PersistirA(IRaizDeAgregacao entidade);
        void PersistirAtualizacaoDa(IRaizDeAgregacao entidade);
        void PersistirDelecaoDa(IRaizDeAgregacao entidade); 
    }
}