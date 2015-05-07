using Integra.Dominio.Teste.Helpers;

namespace Integra.Dominio.Teste.Builders
{
    public class GrupoBuilder
    {
        private int _codigo;

        private GrupoBuilder()
        {
            
        }

        public static GrupoBuilder DadoUmGrupo()
        {
            return new GrupoBuilder();
        }

        public Grupo Build()
        {
            var grupo = new Grupo("Alguma descricao");
            grupo.Setar(it=>it.Codigo, _codigo);
            return grupo;
        }

        public GrupoBuilder ComCodigo(int codigo)
        {
            _codigo = codigo;
            return this;
        }
    }
}