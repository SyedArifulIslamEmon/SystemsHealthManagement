using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IUsuarioRepositorio:IRepositorio<Usuario, int>
    {
        Usuario ObterPor(string nomeDeUsuario);
    }
}