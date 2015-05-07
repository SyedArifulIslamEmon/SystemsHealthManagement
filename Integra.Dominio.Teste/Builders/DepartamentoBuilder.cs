namespace Integra.Dominio.Teste.Builders
{
    public class DepartamentoBuilder
    {
        private DepartamentoBuilder()
        {

        }

        public static DepartamentoBuilder DadoUmDepartamento()
        {
            return new DepartamentoBuilder();
        }

        public Departamento Build()
        {
            return new Departamento();
        }
    }
}