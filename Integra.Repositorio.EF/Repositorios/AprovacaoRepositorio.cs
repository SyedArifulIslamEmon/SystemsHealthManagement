using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class AprovacaoRepositorio: Repositorio<Aprovacao, int>, IAprovacaoRepositorio
    {
        public AprovacaoRepositorio(IUnitOfWork uow) : base(uow)
        {
        }

        public override Aprovacao ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public IList<Aprovacao> ObterAprovacoesDoTipo(TipoDaAprovacao tipo)
        {
            return GetObjectSet().Where(it => it.Tipo == tipo).ToList();
        }
    }
}