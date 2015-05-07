using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.RegrasDeNegocio.Perfil;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;
using System.Linq;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class PerfilTeste
    {
        [Test]
        public void ConsigoAdicionarPermissaoParaUmModulo()
        {
            var modulo = new Modulo();
            var grupo = GrupoBuilder.DadoUmGrupo().Build();

            var perfil = new Perfil(grupo);

            perfil.PermitirModulo(modulo);

            CollectionAssert.Contains(perfil.ModulosPermitidos, modulo);
        }

        [Test]
        public void ConsigoSaberSeUmPerfilTemPermissaoAUmModulo()
        {
            var modulo = new Modulo();
            var grupo = GrupoBuilder.DadoUmGrupo().Build();

            var perfil = new Perfil(grupo);

            perfil.PermitirModulo(modulo);

            var permitido = perfil.ModuloEhPermitido(modulo);

            Assert.IsTrue(permitido);
        }

        [Test]
        public void UmPerfilDevePertencerAUmGrupo()
        {
            var grupo = GrupoBuilder.DadoUmGrupo().Build();

            var perfil = new Perfil(grupo);

            Assert.AreSame(grupo, perfil.Grupo);
        }

        [Test]
        public void NaoConsigoCriarUmPerfilSemUmGrupo()
        {
            try
            {
                new Perfil(null);
                Assert.Fail(RegrasDeNegocioPerfil.DeveConterUmGrupo.Mensagem);
            }
            catch (RegraException regraException)
            {
                Assert.IsAssignableFrom<RegraDeNegocioPerfilDeveConterUmGrupo>(regraException.Erros.First());
            }

        }
    }
}