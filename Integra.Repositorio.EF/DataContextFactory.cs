using StructureMap;

namespace Integra.Repositorio.EF
{
    public class DataContextFactory
    {
        public static IntegraContexto GetDataContext()
        {
            return ObjectFactory.GetInstance<IntegraContexto>();
        }
    }
}
