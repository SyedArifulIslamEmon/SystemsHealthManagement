using System.Collections.Generic;
using System.Linq;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Pessoa;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.Dominio.Teste.Builders;
using Moq;
using NUnit.Framework;

namespace Integra.Dominio.Teste
{
    [TestFixture]

    public class FuncionarioTeste
    {
        private Perfil _perfil;
        private Usuario _usuario;
        private Departamento _departamento;
        private string _telefone;
        private string _nome;
        private List<Programa> _programa;
        private Cargo _cargo;

        [TestFixtureSetUp]
        public void FuncionarioTesteSetUp()
        {
            _perfil = PerfilBuilder.DadoUmPerfil().Build();
            _usuario = UsuarioBuilder.DadoUmUsuario().ComOPerfil(_perfil).Build();
            _departamento = DepartamentoBuilder.DadoUmDepartamento().Build();
            _cargo = CargoBuilder.DadoUmCargo().Build();
            _programa = ProgramaBuilder.DadoUmPrograma().Build();
            _nome = "nome da pessoa";
            _telefone = "13123132132";
        }

        [Test]
        public void UmFuncionariDevePertencerAoGrupoClinicas()
        {
            var grupoIntegra = GrupoBuilder.DadoUmGrupo().ComCodigo(1).Build();
            _perfil = PerfilBuilder.DadoUmPerfil().DoGrupo(grupoIntegra).Build();

            var pessoaRepositorioMock = new Mock<IFuncionarioRepositorio>();
            var grupoRepositorioMock = new Mock<IGrupoRepositorio>();
            grupoRepositorioMock.Setup(it => it.ObterGrupoIntegra()).Returns(grupoIntegra);

            var usuario = UsuarioBuilder.DadoUmUsuario().ComOPerfil(_perfil).Build();

            var servicoPessoa = new FuncionarioServico(pessoaRepositorioMock.Object, grupoRepositorioMock.Object);

            var pessoa = servicoPessoa.AdicionarUmNovoFuncionario(_nome, _telefone, usuario, _departamento, _cargo, _programa, "");

            Assert.AreSame(pessoa.Departamento, _departamento);
        }

        [Test]
        public void NaoConsigoAdicionarUmaFuncionarioSemUmDepartamento()
        {
            try
            {
                new Funcionario(_usuario, _nome, _telefone, null, _cargo, _programa);
                Assert.Fail(RegrasDeNegocioPessoa.DevePertencerAoGrupoIntegraParaTerUmDepartamento.Mensagem);
            }
            catch (RegraException regraDeNegocioException)
            {
                Assert.IsInstanceOf<RegraDeNegocioPessoaDoGrupoIntegraDeveTerUmDepartamento>(regraDeNegocioException.Erros.First());
            }
        }

        [Test]
        public void ConsigoCriarUmFuncionario()
        {
            var funcionario = new Funcionario(_usuario, _nome, _telefone, _departamento, _cargo, _programa);

            Assert.IsNotNull(funcionario);
        }

        [Test]
        public void NaoConsigoCriarUmFuncionarioSemUmCargo()
        {
            try
            {
                new Funcionario(_usuario, _nome, _telefone, _departamento, null, _programa);
                Assert.Fail(RegrasDeNegocioPessoa.DeveTerUmCargo.Mensagem);
            }
            catch (RegraException regraDeNegocioException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioFuncionarioDeveTerUmCargo>(regraDeNegocioException.Erros.First());
            }
        }

        [Test]
        public void PossoAdicionarUmaDescricaoParaUmFuncionario()
        {
            var funcionario = new Funcionario(_usuario, _nome, _telefone, _departamento, _cargo, _programa);

            funcionario.AdicionarDescricao("Uma Descricao");

            Assert.AreEqual("Uma Descricao", funcionario.Descricao);
        }


        [Test]
        public void NaoConsigoCriarUmFuncionarioSemUmPrograma()
        {
            try
            {
                new Funcionario(_usuario, _nome, _telefone, _departamento, _cargo, null);
                Assert.Fail(RegrasDeNegocioPessoa.DeveTerUmPrograma.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioFuncionarioDeveTerUmPrograma>(regraException.Erros.First());
            }
        }

        [Test]
        public void ConsigoInativarUmFuncionario()
        {
            var funcionario = new Funcionario(_usuario, _nome, _telefone, _departamento, _cargo, _programa);

            funcionario.Inativar();

            Assert.IsTrue(funcionario.Inativo);
        }


        [Test]
        public void UmFuncionarioCriadoNaoDeveEstarInativo()
        {
            var funcionario = new Funcionario(_usuario, _nome, _telefone, _departamento, _cargo, _programa);
            Assert.IsFalse(funcionario.Inativo);
        }
    }
}