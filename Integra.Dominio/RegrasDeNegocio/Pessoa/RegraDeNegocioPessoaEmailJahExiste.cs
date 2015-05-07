using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioPessoaEmailJahExiste : RegraDeNegocioBase
    {
        public RegraDeNegocioPessoaEmailJahExiste() : base("O Email informado já esta cadastrado em outra conta!")
        {
        }
    }
}