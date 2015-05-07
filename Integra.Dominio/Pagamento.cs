using Integra.Dominio.Base;
using System;

namespace Integra.Dominio
{
    public class Pagamento : EntidadeBase<int>
    {
        public virtual Arquivo Comprovante { get; set; }
        public virtual string Observacao { get; set; }
        public virtual DateTime DataPagamento { get; set; }

        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}