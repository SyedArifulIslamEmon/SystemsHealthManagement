using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class AprovacaoDeSolicitacao : EntidadeBase<int>
    {
        public virtual bool Aprovado { get; set; }
        public virtual DateTime DataDeAprovacao { get; set; }
        public virtual Cliente Responsavel { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual Programa Programa { get; set; }

        protected override void Validar()
        {

        }
    }
}