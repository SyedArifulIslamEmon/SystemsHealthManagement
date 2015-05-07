using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class SolicitacaoRepositorio : Repositorio<Solicitacao, int>, ISolicitacaoRepositorio
    {
        public SolicitacaoRepositorio(IUnitOfWork uow) : base(uow) { }

        public override Solicitacao ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }
    }
}