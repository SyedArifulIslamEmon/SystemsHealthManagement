using System;
using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Reuniao;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;
using System.Linq;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class ReuniaoTeste
    {
        private Funcionario _funcionario;
        private string _local;
        private string _titulo;
        private DateTime _data;
        private List<Programa> _programa;

        [TestFixtureSetUp]
        public void ReuniaoTesteSetUp()
        {
            _funcionario = FuncionarioBuilder.DadoUmFuncionario().Build();
            PessoaBuilder.DadoUmaPessoa().Build();
            _programa = ProgramaBuilder.DadoUmPrograma().Build();
            _local = "um local";
            _titulo = "Titulo da reuniao";
            SystemTime.SetCurrentTime = () => DateTime.Now;
            _data = SystemTime.Now;
        }

        [Test]
        public void UmaReuniaoNaoPodeSerCriadaSemUmPrograma()
        {
            try
            {
                new Reuniao(null, _funcionario, _local, _titulo, _data, StatusDaReunicao.Pendente);
                Assert.Fail(RegrasDeNegocioReuniao.RequerUmPrograma.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsInstanceOf<RegraDeNegocioReuniaoRequerUmPrograma>(regraException.Erros.First());
            }
        }

        [Test]
        public void ConsigoAdicionarAtasEmUmaReuniao()
        {
            var reuniao = new Reuniao(new Programa(), _funcionario, _local, "ASsunto", _data, StatusDaReunicao.Concluido);

            var ata = new Ata(_funcionario);
            reuniao.AdicionarAta(ata);

            CollectionAssert.Contains(reuniao.Atas, ata);
        }
    }
}
