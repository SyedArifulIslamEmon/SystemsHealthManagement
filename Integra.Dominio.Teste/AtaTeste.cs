using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Ata;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class AtaTeste
    {
        [Test]
        public void NaoPossoCriarUmaAtaSemUmResponsavel()
        {
            try
            {
                new Ata(null);
                Assert.Fail(RegrasDeNegocioAta.RequerUmResponsavel.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioAtaRequerUmResponsavel>(regraException.Erros.First());
            }
        }

        [Test]
        public void PossoAdicionarAnexosEmUmaAta()
        {
            var responsavel = FuncionarioBuilder.DadoUmFuncionario().Build();
            var ata = new Ata(responsavel);
            var arquivo = ArquivoBuilder.DadoUmArquivo().Build();

            ata.AdicionarAnexo(arquivo);

            CollectionAssert.Contains(ata.Anexos ,arquivo);
        }

    }
}
