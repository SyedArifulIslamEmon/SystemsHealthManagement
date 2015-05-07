using System.Collections.Generic;
using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IFuncionarioRepositorio:IRepositorio<Funcionario, int>
    {
        List<Funcionario> ObterTodosDoGrupo(Grupo grupo);
        List<Funcionario> ObterTodosQueNaoEstaoNaEquipe(Equipe equipe);
    }
}