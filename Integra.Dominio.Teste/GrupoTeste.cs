using System.Linq;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Grupo;
using NUnit.Framework;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class GrupoTeste
    {
        [Test]
        public void ConsigoCriarUmGrupoComUmaDescricao()
        {
            const string descricao = "Uma Descrição";

            var grupo = new Grupo(descricao);

            Assert.AreEqual(descricao, grupo.Descricao);
        }

        [Test]
        public void NaoConsigoCriarUmGrupoSemUmaDescricaoValida()
        {
            try
            {
                new Grupo(string.Empty);
                Assert.Fail(RegrasDeNegocioGrupo.DeveConterUmaDescricaoValida.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioGrupoDeveConterUmaDescricaoValida>(regraException.Erros.First());
            }
        }
    }
}
