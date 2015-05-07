using System.Web;
using Integra.Dominio;

namespace Integra.Web.Helpers
{
    public static class SessionHelpers
    {
        public static Programa ProgramaAtivo(this HttpSessionStateBase session)
        {
            return session[SessionKeys.ProgramaAtivo] == null ? null : (Programa)session[SessionKeys.ProgramaAtivo];
        }

        public static void SetProgramaAtivo(this HttpSessionStateBase session, Programa programa)
        {
            session[SessionKeys.ProgramaAtivo] = programa;
        }
    }
}