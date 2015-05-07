using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IEquipeRepositorio: IRepositorio<Equipe, int>
    {
        Equipe ObterPor(Programa programa);
    }
}