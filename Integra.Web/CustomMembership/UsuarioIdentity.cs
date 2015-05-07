using System.Security.Principal;
using Integra.Dominio;

namespace Integra.Web.CustomMembership
{
    public class UsuarioIdentity : IIdentity
    {
        public Pessoa Pessoa { get; set; }

        public UsuarioIdentity(Pessoa pessoa)
        {
            Pessoa = pessoa;
        }

        public string AuthenticationType
        {
            get { return "CustomIdentity"; }
        }

        public bool IsAuthenticated
        {
            get { return Pessoa != null; }
        }

        public string Name
        {
            get { return Pessoa.Usuario.NomeDeUsuario; }
        }
    }
}