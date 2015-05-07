using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class Programa: EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string IdentPrograma { get; set; }
        public virtual int CodPrograma { get; set; } 

        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}