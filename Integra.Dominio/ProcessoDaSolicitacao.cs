using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class ProcessoDaSolicitacao : EntidadeBase<int>
    {
        public virtual DateTime DataDoProcesso { get; set; }
        public virtual string Solucao { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual Funcionario Responsavel { get; set; }
        public virtual Programa Programa { get; set; }

        protected override void Validar()
        {

        }
    }
}