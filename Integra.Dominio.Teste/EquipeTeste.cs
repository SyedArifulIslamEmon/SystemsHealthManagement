
using System.Collections.Generic;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Equipe;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class EquipeTeste
    {
        private Funcionario _funcionario;
        private List<Programa> _programa;

        [TestFixtureSetUp]
        public void EquipeTEsteSetUp()
        {
            _funcionario = FuncionarioBuilder.DadoUmFuncionario().ComOCogio(1).Build();

            _programa = ProgramaBuilder.DadoUmPrograma().Build();

        }

        [Test]
        public void NaoConsigoAdicionarOMesmoFuncionarioNaEquipe()
        {
            var equipe = new Equipe(new Programa());
            equipe.AdicionarMembro(_funcionario);
            try
            {
                equipe.AdicionarMembro(_funcionario);
                Assert.Fail(RegrasDeNegocioEquipe.FuncionarioJaPertenceAEstaEquipe.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsInstanceOf<RegraDeNegocioEquipeFuncionarioJaPertenceAEstaEquipe>(regraException.Erros.First());
            }
        }

        [Test]
        public void UmaEquipeDeveConterUmPrograma()
        {
            var programa = new Programa();
            var equipe = new Equipe(programa);
            Assert.AreSame(programa, equipe.Programa);
        }

        [Test]
        public void NaoPossoInformarNullParaOPrograma()
        {
            try
            {
                new Equipe(null);
                Assert.Fail(RegrasDeNegocioEquipe.DeveTerUmPrograma.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsInstanceOf<RegraDeNegocioEquipeDeveTerUmPrograma>(regraException.Erros.First());
            }
        }
    }
}
