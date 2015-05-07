using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class Departamento:EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }

        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}