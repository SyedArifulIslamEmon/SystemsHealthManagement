using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioPessoaEmailJahExiste : RegraDeNegocioBase
    {
        public RegraDeNegocioPessoaEmailJahExiste() : base("O Email informado j� esta cadastrado em outra conta!")
        {
        }
    }
}