using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using System.Linq;
using Integra.Dominio.Repositorios;

namespace Integra.Repositorio.EF.Repositorios
{
    public class FuncionarioRepositorio : Repositorio<Funcionario, int>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Funcionario ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<Funcionario> ObterTodosDoGrupo(Grupo grupo)
        {
            return GetObjectSet().Where(it => it.Usuario.Perfil.Grupo.Codigo == grupo.Codigo).ToList();
        }

        public List<Funcionario> ObterTodosQueNaoEstaoNaEquipe(Equipe equipe)
        {
            return ObterTodos().Where(it => !equipe.MenbrosDaEquipe.Exists(e => e.Codigo == it.Codigo)).ToList();
        }
    }
}