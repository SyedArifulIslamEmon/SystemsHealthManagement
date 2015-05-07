using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class DepartamentoRepositorio:Repositorio<Departamento, int>, IDepartamentoRepositorio
    {
        public DepartamentoRepositorio(IUnitOfWork uow) : base(uow)
        {
        }

        public override Departamento ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}