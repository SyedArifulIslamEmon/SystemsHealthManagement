using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class AnaliseDeSolicitacao : EntidadeBase<int>
    {
        public virtual DateTime DataDaAnalise { get; set; }
        public virtual Funcionario Responsavel { get; set; }
        public virtual string Analise { get; set; }
        public virtual decimal Custo { get; set; }
        public virtual int DiasParaEntrega { get; set; }
        public virtual string Atividade { get; set; }
        public virtual Programa Programa { get; set; }

        protected override void Validar()
        {

        }
    }
}