namespace Integra.Dominio.Teste.Builders
{
    public class CargoBuilder
    {
        private CargoBuilder()
        {
            
        }

        public static CargoBuilder DadoUmCargo()
        {
            return new CargoBuilder();
        }

        public Cargo Build()
        {
            return  new Cargo();
        }
    }
}