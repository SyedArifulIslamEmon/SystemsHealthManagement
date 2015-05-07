using System;
using System.Threading;
using System.Web;
using Integra.Dominio.Base.Dominio.Base.Infra;
using Integra.Dominio.Repositorios;
using StructureMap;

namespace Integra.Web.CustomMembership
{
    public class SecurityHelper
    {
        public static bool Authenticate(string nomeDoUsuario, string password)
        {
            var usuarioRepositorio = ObjectFactory.GetInstance<IPessoaRepositorio>();
            var pessoa = usuarioRepositorio.ObterPeloNomeDeUsuario(nomeDoUsuario);
            if (null != pessoa)
            {
                if (!pessoa.Inativo && Crypto.VerifyHashedPassword(pessoa.Usuario.Senha, password))
                {
                    var identity = new UsuarioIdentity(pessoa);
                    var principal = new UsuarioPrincipal(identity);
                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;
                    return true;
                }
            }
            throw new ApplicationException("Senha ou usuário inválido.");
        }

        public static void Logout()
        {
            Thread.CurrentPrincipal = null;
            HttpContext.Current.User = null;
        }
    }
}