using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IGrupoRepositorio : IRepositorio<Grupo, int>
    {
        Grupo ObterPor(string nome);
        Grupo ObterGrupoIntegra();
    }
}