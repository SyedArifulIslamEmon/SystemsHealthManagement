using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class Estorno:EntidadeBase<int>
    {
        public string Observacao { get; set; }

        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}