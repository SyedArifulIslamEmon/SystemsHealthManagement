using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class CargoRepositorio : Repositorio<Cargo, int>, ICargoRepositorio
    {
        public CargoRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Cargo ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}