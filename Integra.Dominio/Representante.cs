using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class Representante: EntidadeBase<int>, IRaizDeAgregacao
    {
        public string Nome { get; set; }

        protected override void Validar()
        {
            
        }
    }
}