using System;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class RepresentanteRegional: EntidadeBase<int>, IRaizDeAgregacao
    {
        public string Nome { get; set; }

        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
