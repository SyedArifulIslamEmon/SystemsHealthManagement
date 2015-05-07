using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;
using Integra.Dominio.Base;

namespace Integra.Repositorio.EF.Repositorios
{
    public class GrupoRepositorio : Repositorio<Grupo, int>, IGrupoRepositorio
    {
        public GrupoRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Grupo ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(grupo => grupo.Codigo == codigo);
        }

        public Grupo ObterPor(string nome)
        {
            return GetObjectSet().SingleOrDefault(grupo => grupo.Descricao.ToUpper().Equals(nome.ToUpper()));
        }

        public Grupo ObterGrupoIntegra()
        {
            return ObterPor(Grupo.Grupos.Integra.GetStringValue());
        }
    }
}