using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ModuloRepositorio: Repositorio<Modulo, int>, IModuloRepositorio
    {
        public ModuloRepositorio(IUnitOfWork uow) : base(uow)
        {}

        public override Modulo ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(m => m.Codigo == codigo);
        }

        public Modulo ObterPor(string nomeDoModulo)
        {
            return GetObjectSet().FirstOrDefault(m => m.Nome == nomeDoModulo);
        }
    }
}