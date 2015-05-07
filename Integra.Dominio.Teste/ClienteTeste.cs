using System.Collections.Generic;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Pessoa;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class ClienteTeste
    {
        private Usuario _usuario;
        private string _telefone;
        private string _nome;
        private List<Programa> _programa;

        [TestFixtureSetUp]
        public void ClienteTesteSetUp()
        {
            _usuario = UsuarioBuilder.DadoUmUsuario().Build();
            _programa = ProgramaBuilder.DadoUmPrograma().Build();
            _telefone = "32566589";
            _nome = "Nome da pessoa";
        }

        [Test]
        public void UmaClienteDeveTerUmUsuario()
        {
            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            Assert.AreSame(_usuario, cliente.Usuario);
        }

        [Test]
        public void UmaClienteTemUmNome()
        {

            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            Assert.AreSame(_nome, cliente.Nome);
        }

        [Test]
        public void UmaClienteTemUmTelefone()
        {

            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            Assert.AreEqual(_telefone, cliente.Telefone);
        }

        [Test]
        public void UmClientePodeSerInativado()
        {
            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            cliente.Inativar();
            Assert.IsTrue(cliente.Inativo);
        }

        [Test]
        public void UmClienteCriadoNaoDeveEstarInativo()
        {
            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            Assert.IsFalse(cliente.Inativo);
        }

        [Test]
        public void UmClienteDeveConterUmPrograma()
        {
            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            Assert.AreSame(_programa, cliente.ProgramasPermitidos);
        }

        [Test]
        public void ConsigoInformarUmCrmDeUmCliente()
        {
            var crm = CrmBuilder.DadoUmCRM().Build();
            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            cliente.InformarCrm(crm);
            Assert.AreSame(crm,cliente.Crm);
        }

        [Test]
        public void NaoConsigoInformarUmCrmVazioParaOCliente()
        {
            var cliente = new Cliente(_usuario, _nome, _telefone, _programa);
            try
            {
                cliente.InformarCrm(null);
                Assert.Fail(RegrasDeNegocioPessoa.NaoPodeInformarUmCrmVazio.Mensagem); 
            }
            catch (RegraException regraException)
            {
                Assert.IsInstanceOf<RegraDeNegocioClienteNaoDeveInformarUmCrmVazio>(regraException.Erros.First());
            }
        }
    }
}
