using System.Security.Principal;
using Integra.Dominio;
using Integra.Web.CustomMembership;

namespace Integra.Web.Helpers
{
    public static class UsuarioExtension
    {
        public static Pessoa ToPessoa(this IPrincipal usuario)
        {
            if (usuario.Identity is UsuarioIdentity)
            {
                var usuarioIdentity = usuario.Identity as UsuarioIdentity;
                if (usuarioIdentity != null)
                    return usuarioIdentity.Pessoa;
            }
            return null;
        }
    }
}