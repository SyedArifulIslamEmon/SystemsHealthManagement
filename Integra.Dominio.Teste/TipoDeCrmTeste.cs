using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.TipoDeCrm;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class TipoDeCrmTeste
    {
        [Test]
        public void ConsigoCriarUmTipoDeCrmComUmaDescricao()
        {
            var descricao = "Representante";

            var crm = new TipoDeCrm(descricao, "R");

            Assert.AreEqual(descricao, crm.Descricao);
        }

        [Test]
        public void NaoConsigoCriarUmTipoDeCrmSemUmaDescricaoValida()
        {
            try
            {
                new TipoDeCrm(string.Empty,"R");
                Assert.Fail(RegrasDeNegocioTipoDeCrm.DeveConterUmaDescricao.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioTipoDeCrmDeveConterUmaDescricao>(regraException.Erros.First());
            }
        }
    }
}
