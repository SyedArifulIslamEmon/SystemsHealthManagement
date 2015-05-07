using System.Security.Principal;

namespace Integra.Web.CustomMembership
{
    public class UsuarioPrincipal : IPrincipal
    {
        private readonly UsuarioIdentity _identity;

        public UsuarioPrincipal(UsuarioIdentity identity)
        {
            _identity = identity;
        }


        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }
    }
}
