using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Usuario
{
    public class RegraDeNegocioUsuarioONomeDeUsuarioDeveSerUmEmailValido : RegraDeNegocioBase
    {
        public RegraDeNegocioUsuarioONomeDeUsuarioDeveSerUmEmailValido() : base("O Nome de usuario deve ser um email válido!")
        {
        }
    }
}