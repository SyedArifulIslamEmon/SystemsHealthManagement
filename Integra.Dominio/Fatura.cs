using System;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Fatura;

namespace Integra.Dominio
{
    public class Fatura : EntidadeBase<int>, IRaizDeAgregacao
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TipoDaFatura Tipo { get; set; }
        public decimal Valor { get; set; }
        public TipoDeDocumento Documento { get; set; }
        public string NumeroDoDocumento { get; set; }
        public StatusDaFatura Status { get; set; }
        public virtual Programa Programa { get; private set; }

        protected Fatura() { }

        public Fatura(Programa programa)
        {
            Programa = programa;
            Validar();
        }

        protected override sealed void Validar()
        {
            if(Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioFatura.DeveTerUmPrograma);
            NotificarSeHouverAlgumErro();
        }
    }

    public enum TipoDeDocumento
    {
        [StringValue("Nota Fiscal")]
        NotaFiscal = 1,
        [StringValue("Nota de Débito")]
        NadaADeclarar = 2
    }

    public enum StatusDaFatura
    {
        [StringValue("Previsto")]
        Previsto = 1,
        [StringValue("Realizado")]
        Realizado = 2
    }

    public enum TipoDaFatura
    {
        [StringValue("Única")]
        Unica = 1,
        [StringValue("Mensal")]
        Mensal = 2,
        [StringValue("Variável")]
        Variavel = 3
    }
}