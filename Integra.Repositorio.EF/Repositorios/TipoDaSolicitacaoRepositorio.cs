using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class TipoDaSolicitacaoRepositorio : Repositorio<TipoDaSolicitacao, int>, ITipoDaSolicitacaoRepositorio
    {
        public TipoDaSolicitacaoRepositorio(IUnitOfWork uow) : base(uow) { }

        public override TipoDaSolicitacao ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}