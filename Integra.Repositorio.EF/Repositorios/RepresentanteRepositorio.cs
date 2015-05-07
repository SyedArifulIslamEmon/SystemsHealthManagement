using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class RepresentanteRepositorio : Repositorio<Representante, int>, IRepresentanteRepositorio, IRaizDeAgregacao
    {
        public RepresentanteRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Representante ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}