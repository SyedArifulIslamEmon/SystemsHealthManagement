using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class TratamentoRepositorio : Repositorio<Tratamento, int>, ITratamentoRepositorio
    {
        public TratamentoRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Tratamento ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<Tratamento> ObterTodos(Programa programa)
        {
            return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
        }
    }
}
