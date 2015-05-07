using System;
using System.Linq;
using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Usuario;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class UsuarioTeste
    {
        private Perfil _perfil;
        private string _nomeDeUsuario;
        private string _senha;

        [TestFixtureSetUp]
        public void UsuarioTestSetUp()
        {
            _nomeDeUsuario = "meuUsuario@alguma.com";
            _senha = "minhasenha";
            _perfil = PerfilBuilder.DadoUmPerfil().Build();
        }

        [Test]
        public void UmUsuarioDevePertencerAUmPerfil()
        {
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);

            Assert.AreSame(_perfil, usuario.Perfil);
        }

        [Test]
        public void NaoConsigoCriarUmUsuarioSemPertencerAUmPerfil()
        {
            try
            {
                new Usuario(_senha, _nomeDeUsuario, null);
                Assert.Fail(RegrasDeNegocioUsuario.DevePertencerAUmPerfil.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioUsuarioDeveConterUmPerfil>(regraException.Erros.First());
            }
        }

        [Test]
        public void UmUsuarioDeveConterUmNomeDeUsuario()
        {
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);

            Assert.AreEqual(_nomeDeUsuario, usuario.NomeDeUsuario);
        }

        [Test]
        public void UmUsuarioDeveConterUmaSenha()
        {
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);

            Assert.AreEqual(_senha, usuario.Senha);
        }

        [Test]
        public void NaoConsigoCriarUmUsuarioSeONomeDeUsuarioNaoForUmEmailValido()
        {
            try
            {
                const string nomeInvalido = "nomeinvalido";
                new Usuario(nomeInvalido, _senha, _perfil);
                Assert.Fail(RegrasDeNegocioUsuario.NomeDeUsuarioDeveSerUmEmailValido.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioUsuarioONomeDeUsuarioDeveSerUmEmailValido>(regraException.Erros.First());
            }
        }

        [Test]
        public void NaoConsigoCriarUmUsuarioSemSenha()
        {
            try
            {
                new Usuario(_nomeDeUsuario, string.Empty, _perfil);
                Assert.Fail(RegrasDeNegocioUsuario.DeveConterUmaSenhaValida.Mensagem);
            }
            catch (RegraException regraDeNegocioException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioUsuarioDeveConterUmaSenhaValida>(regraDeNegocioException.Erros.First());
            }
        }

        [Test]
        public void ConsigoAlterarMinhaSenha()
        {
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);
            const string novaSenha = "NovaSenha";
            usuario.AlterarSenha(novaSenha);
            Assert.AreEqual(novaSenha, usuario.Senha);
        }

        [Test]
        public void NomeDeUsuarioNaoPodeSerNulo()
        {
            try
            {
                new Usuario(null, _senha, _perfil);
                Assert.Fail(RegrasDeNegocioUsuario.NomeDeUsuarioDeveSerUmEmailValido.Mensagem);
            }
            catch (RegraException regraDeNegocioException)
            {
                Assert.IsInstanceOf<RegraDeNegocioUsuarioONomeDeUsuarioDeveSerUmEmailValido>(regraDeNegocioException.Erros.First());
            }
        }

        [Test]
        public void UsuarioDeveArmazernarADataDeCriacao()
        {
            var data = new DateTime(2010, 3, 1);
            SystemTime.SetCurrentTime = () => data;
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);
            Assert.AreEqual(usuario.DataDeCriacao, data);
        }

        [Test]
        public void UsuarioDeverRegistrarADataEHoraDoUltimoAcesso()
        {
            var data = DateTime.Now;
            SystemTime.SetCurrentTime = () => data;
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);
            usuario.RegristarAcesso();
            Assert.AreEqual(usuario.UltimoAcesso, data);
        }

        [Test]
        public void ConsigoSaberSeUmUsuarioPertenceAUmGrupo()
        {
            var grupo = GrupoBuilder.DadoUmGrupo().ComCodigo(1).Build();
            var perfil = PerfilBuilder.DadoUmPerfil().DoGrupo(grupo).Build();

            var usuario = new Usuario(_nomeDeUsuario, _senha, perfil);

            var pertenceAoGrupo = usuario.PertenceAoGrupo(grupo);

            Assert.IsTrue(pertenceAoGrupo);
        }

        [Test]
        public void ConsigoSaberSeUmUsuarioPertenceAUmGrupoMesmoNaoInfomandoValor()
        {
            var usuario = new Usuario(_nomeDeUsuario, _senha, _perfil);

            var pertenceAoGrupo = usuario.PertenceAoGrupo(null);

            Assert.IsFalse(pertenceAoGrupo);
        }
    }
}