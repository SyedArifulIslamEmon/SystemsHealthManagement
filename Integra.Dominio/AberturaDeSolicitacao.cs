using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class AberturaDeSolicitacao : EntidadeBase<int>
    {
        public virtual TipoDaSolicitacao Tipo { get; set; }
        public virtual DateTime DataDaAbertura { get; set; }
        public virtual Pessoa Responsavel { get; set; }
        public virtual string Protocolo { get; set; }
        public virtual string Solicitacao { get; set; }
        public virtual Programa Programa { get; set; }

        protected override void Validar()
        {

        }
    }
}