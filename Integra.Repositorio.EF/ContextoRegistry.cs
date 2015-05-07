using StructureMap.Configuration.DSL;

namespace Integra.Repositorio.EF
{
    public class ContextoRegistry : Registry
    {
        public ContextoRegistry()
        {
            ForSingletonOf<IntegraContexto>().HybridHttpOrThreadLocalScoped().Use<IntegraContexto>();
        }
    }
}