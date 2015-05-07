using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario, int>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Usuario ObterPor(int id)
        {
            return GetObjectSet().SingleOrDefault(u => u.Codigo == id);
        }

        public Usuario ObterPor(string nomeDeUsuario)
        {
            var us = GetObjectSet().SingleOrDefault(u => u.NomeDeUsuario.ToUpper().Equals(nomeDeUsuario.ToUpper()));
            return us;
        }
    }
}