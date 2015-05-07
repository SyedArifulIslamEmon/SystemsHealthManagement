using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.ServicosContratados;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class ServicosContratadosTeste
    {
        [Test]
        public void NaoPossoDeixarDeInformarUmPrograma()
        {
            try
            {
                new ServicosContratados(null);
                Assert.Fail(RegrasDeNegocioServicosContratados.DeveTerUmPrograma.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsInstanceOf<RegrasDeNegocioServicosContratadosDeveTerUmPrograma>(regraException.Erros.First());
            }
        }
    }
}
