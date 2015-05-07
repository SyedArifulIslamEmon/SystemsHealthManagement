using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios 
{
    public interface IModuloRepositorio : IRepositorio<Modulo, int>
    {
        Modulo ObterPor(string nomeDoModulo);
    }
}