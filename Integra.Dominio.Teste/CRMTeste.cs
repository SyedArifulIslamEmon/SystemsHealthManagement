using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Crm;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class CRMTeste
    {
        [Test]
        public void UmCrmDeveConterONumeroDeCrm()
        {
            var numeroDoCrm = "12312kkjasdj34çlaksd";
            var tipo = new TipoDeCrm("Representante","R");
            var crm = new CRM(numeroDoCrm, tipo ,"");

            Assert.AreEqual(numeroDoCrm, crm.NumeroDoCRM);
        }

        [Test]
        public void UmCrmDeveConterUmTipoDoCrm()
        {
            var tipo = new TipoDeCrm("Representante", "R");
            var crm = new CRM("123123123123", tipo, "");
            Assert.AreSame(tipo, crm.Tipo);
        }
        /*
        [Test]
        public void NaoConsigoCriarUmCrmSemUmNumero()
        {
            var tipo = new TipoDeCrm("Representante", "R");

            try
            {
                new CRM(string.Empty, tipo,string.Empty);
                Assert.Fail(RegrasDeNegocioCrm.RequerUmNumeroDoCrmValido.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioCrmRequerUmNumeroValido>(regraException.Erros.First());
            }
        }
        */
        [Test]
        public void NaoCOnsigoCriarUmmCrmSemUmTipoDeCrm()
        {
            var numeroDoCrm = "NumeroDoCrm123123123";

            try
            {
                new CRM(numeroDoCrm, null, "");
                Assert.Fail(RegrasDeNegocioCrm.RequerUmTipoDeCrm.Mensagem);
            }
            catch (RegraException regraDeNegocio)
            {
                Assert.IsAssignableFrom<RegraDeNegocioCrmRequerUmTipoDeCrm>(regraDeNegocio.Erros.First());
            }
        }
    }
}
