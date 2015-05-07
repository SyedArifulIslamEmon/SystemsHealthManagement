using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ServicosContratadosRepositorio:Repositorio<ServicosContratados, int>, IServicosContratadosRepositorio
    {
        public ServicosContratadosRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override ServicosContratados ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<ServicosContratados> ObterTodos(Programa programa)
        {
            return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
        }
    }
}
