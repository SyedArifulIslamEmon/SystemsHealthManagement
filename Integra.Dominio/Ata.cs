using System;
using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.RegrasDeNegocio.Ata;

namespace Integra.Dominio
{
    public class Ata : EntidadeBase<int>
    {
        public virtual Funcionario Responsavel { get; set; }
        public string Assunto { get; set; }
        public StatusDaAta Status { get; set; }
        public DateTime InicioDoPrazo { get; set; }
        public DateTime FinalDoPrazo { get; set; }
        public string Anotacoes { get; set; }
        public virtual List<Arquivo> Anexos { get; private set; }
        public virtual Programa Programa { get; set; }

        protected Ata() { }

        public Ata(Funcionario responsavel)
        {
            Anexos = new List<Arquivo>();
            Responsavel = responsavel;
            Validar();
        }

        protected override sealed void Validar()
        {
            if (Responsavel == null)
                AdicionarRegraQuebrada(RegrasDeNegocioAta.RequerUmResponsavel);
            NotificarSeHouverAlgumErro();
        }

        public void AdicionarAnexo(Arquivo arquivo)
        {
            Anexos.Add(arquivo);
        }

        public void RemoverAnexo(Arquivo anexo)
        {
            Anexos.Remove(anexo);
        }
    }

    public enum StatusDaAta
    {
        [StringValue("Pendente")]
        Pendente,
        [StringValue("Em andamento")]
        Andamento,
        [StringValue("Concluido")]
        Concluido,
        [StringValue("Cancelado")]
        Cancelado
    }
}