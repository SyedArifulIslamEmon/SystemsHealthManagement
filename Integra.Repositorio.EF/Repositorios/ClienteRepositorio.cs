using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ClienteRepositorio:Repositorio<Cliente,int>, IClienteRepositorio
    {
        public ClienteRepositorio(IUnitOfWork uow) : base(uow)
        {
        }

        public override Cliente ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}