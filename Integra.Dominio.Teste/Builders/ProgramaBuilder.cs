using System.Collections.Generic;

namespace Integra.Dominio.Teste.Builders
{
    public class ProgramaBuilder
    {
        private ProgramaBuilder()
        {
            
        }

        public static ProgramaBuilder DadoUmPrograma()
        {
            return  new ProgramaBuilder();
        }

        public List<Programa> Build()
        {
            return  new List<Programa>();
        }
    }
}