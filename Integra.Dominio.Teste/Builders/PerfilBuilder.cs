namespace Integra.Dominio.Teste.Builders
{
    public class PerfilBuilder
    {
        private Grupo _grupo = GrupoBuilder.DadoUmGrupo().Build();

        private PerfilBuilder()
        {

        }

        public static PerfilBuilder DadoUmPerfil()
        {
            return new PerfilBuilder();
        }

        public Perfil Build()
        {
            return new Perfil(_grupo);
        }

        public PerfilBuilder DoGrupo(Grupo grupo)
        {
            _grupo = grupo;
            return this;
        }
    }
}