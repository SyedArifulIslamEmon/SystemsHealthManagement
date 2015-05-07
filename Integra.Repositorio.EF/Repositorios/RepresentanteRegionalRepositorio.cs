using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class RepresentanteRegionalRepositorio : Repositorio<RepresentanteRegional, int>, IRepresentanteRegionalRepositorio
    {
        public RepresentanteRegionalRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override RepresentanteRegional ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}