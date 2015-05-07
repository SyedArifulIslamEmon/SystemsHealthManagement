using System.Linq;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;

namespace Integra.Repositorio.EF.Repositorios
{
    public class GerenteRepositorio : Repositorio<Gerente, int>, IGerenteRepositorio
    {
        public GerenteRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Gerente ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}