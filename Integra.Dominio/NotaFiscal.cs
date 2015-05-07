using System;
using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class NotaFiscal : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual bool Devolvida { get; private set; }
        public virtual Clinica Clinica { get; set; }
        public virtual Funcionario Responsavel { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual string Numero { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual DateTime DataCriacao { get; private set; }
        public virtual DateTime DataRecebimento { get; set; }
        public virtual IList<Infusao> Infusoes { get; set; }
        public virtual Arquivo Arquivo { get; set; }
        public virtual Pagamento Pagamento { get; private set; }
        public virtual Estorno Estorno { get; private set; }
        public virtual string TipoDeDevolucao { get; private set; }
        public virtual string Motivo { get; private set; }
        public virtual Programa Programa { get; set; }

        public NotaFiscal()
        {
            DataCriacao = SystemTime.Now;
            Infusoes = new List<Infusao>();
        }
        protected override void Validar()
        {
            throw new NotImplementedException();
        }

        public void Pagar(Pagamento pagamento)
        {
            if (Pagamento == null)
            {
                Pagamento = pagamento;
                foreach (var infusao in Infusoes)
                    infusao.Pagar();
            }
        }

        public void Estornar(Estorno estorno)
        {
            if (Pagamento != null && Estorno == null)
                Estorno = estorno;
        }

        public void Devolver(string motivo, string tipoDeDevolucao)
        {
            Motivo = motivo;
            TipoDeDevolucao = tipoDeDevolucao;
            Devolvida = true;
        }

        public string Status()
        {
            if (Estorno != null)
                return "Estornada";
            if (Pagamento != null)
                return "Pago";
            if (Devolvida)
                return "Devolvida";
            return "Aberto";
        }
    }
}
