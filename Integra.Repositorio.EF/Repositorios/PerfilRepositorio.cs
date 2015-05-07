using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class PerfilRepositorio:Repositorio<Perfil, int>, IPerfilRepositorio
    {
        public PerfilRepositorio(IUnitOfWork uow) : base(uow)
        {
        }

        public override Perfil ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(p => p.Codigo == codigo);
        }
    }
}