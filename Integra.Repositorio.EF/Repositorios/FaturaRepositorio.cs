using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class FaturaRepositorio:Repositorio<Fatura, int>, IFaturaRepositorio
    {
        public FaturaRepositorio(IUnitOfWork uow) : base(uow)
        {
        }

        public override Fatura ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<Fatura> ObterTodos(Programa programa)
        {
            return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
        }
    }
}