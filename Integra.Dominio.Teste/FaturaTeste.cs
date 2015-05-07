
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Fatura;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class FaturaTeste
    {
        [Test]
        public void NaoPossoDeixarDeInformarUmPrograma()
        {
            try
            {
                new Fatura(null);
                Assert.Fail(RegrasDeNegocioFatura.DeveTerUmPrograma.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsInstanceOf<RegraDeNegocioFaturaDeveTerUmPrograma>(regraException.Erros.First());
            }
        }
    }
}

