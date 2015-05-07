using System.Collections.Generic;
using Integra.Dominio.Teste.Builders;
using NUnit.Framework;

namespace Integra.Dominio.Teste
{
    [TestFixture]
    public class ModuloTeste
    {
        [Test]
        public void ConsigoSaberSeUmUsuarioPodeAcessarUmModulo()
        {
            var perfil = PerfilBuilder.DadoUmPerfil().Build();
            var modulo = new Modulo { Perfils = new List<Perfil> { perfil } };
            var usuario = UsuarioBuilder.DadoUmUsuario().ComOPerfil(perfil).Build();

            var permitido = modulo.TemPermissao(usuario);

            Assert.IsTrue(permitido);
        }
    }
}