using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using System.Linq;
using Integra.Dominio.Repositorios;

namespace Integra.Repositorio.EF.Repositorios
{
    public class EquipeRepositorio : Repositorio<Equipe, int>, IEquipeRepositorio
    {
        public EquipeRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Equipe ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public Equipe ObterPor(Programa programa)
        {
            return GetObjectSet()
                .SingleOrDefault(it => it.Programa.Codigo == programa.Codigo);
        }
    }
}