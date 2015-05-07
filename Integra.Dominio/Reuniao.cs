using System;
using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Reuniao;

namespace Integra.Dominio
{
    public class Reuniao : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual DateTime Criacao { get; private set; }
        public virtual Programa Programa { get; private set; }
        public virtual DateTime Realizacao { get; set; }
        public virtual string Assunto { get; set; }
        public virtual string Local { get; set; }
        public virtual Funcionario Responsavel { get; set; }
        public virtual List<Pessoa> Participantes { get; private set; }
        public virtual StatusDaReunicao Status { get; set; }
        public virtual List<Arquivo> Anexos { get; private set; }
        public virtual List<Ata> Atas { get; private set; }

        protected Reuniao() { }

        public Reuniao(Programa programa, Funcionario funcionario, string local, string assunto, DateTime realizacao, StatusDaReunicao status)
        {
            Participantes = new List<Pessoa>();
            Anexos = new List<Arquivo>();
            Atas = new List<Ata>();
            Criacao = SystemTime.Now;
            Responsavel = funcionario;
            Local = local;
            Assunto = assunto;
            Status = status;
            Realizacao = realizacao;
            Programa = programa;
            Validar();
        }

        protected override sealed void Validar()
        {
            if (Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioReuniao.RequerUmPrograma);
            NotificarSeHouverAlgumErro();
        }

        public void AdicionarParticipante(Pessoa participante)
        {
            Participantes.Add(participante);
        }

        public void AdicionarAnexo(Arquivo anexo)
        {
            Anexos.Add(anexo);
        }

        public void AdicionarAta(Ata ata)
        {
            Atas.Add(ata);
        }

        public void RemoverAta(Ata ata)
        {
            Atas.Remove(ata);
        }

        public void RemoverAnexo(Arquivo anexo)
        {
            Anexos.Remove(anexo);
        }
    }

    public enum StatusDaReunicao
    {
        [StringValue("Pendente")]
        Pendente,
        [StringValue("Em Andamento")]
        Andamento,
        [StringValue("Concluido")]
        Concluido,
        [StringValue("Cancelado")]
        Cancelado
    }
}