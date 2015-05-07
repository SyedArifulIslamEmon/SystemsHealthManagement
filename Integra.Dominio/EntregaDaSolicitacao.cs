using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class EntregaDaSolicitacao : EntidadeBase<int>
    {
        public virtual bool Aceita { get; set; }
        public virtual Cliente Responsavel { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual DateTime DataDoAceite { get; set; }
        public virtual Programa Programa { get; set; }

        protected override void Validar()
        {

        }
    }
}