using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class TipoDeCrmRepositorio : Repositorio<TipoDeCrm, int>, ITipoDeCrmRepositorio
    {
        public TipoDeCrmRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override TipoDeCrm ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(tipoDeCrm => tipoDeCrm.Codigo == codigo);
        }
    }
}