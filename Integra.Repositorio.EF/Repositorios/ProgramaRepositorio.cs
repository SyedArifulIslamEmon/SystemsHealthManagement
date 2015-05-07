using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ProgramaRepositorio : Repositorio<Programa, int>, IProgramaRepositorio
    {
        public ProgramaRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Programa ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}