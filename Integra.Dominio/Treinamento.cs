using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Treinamento;
using System;
using System.Collections.Generic;

namespace Integra.Dominio
{
    public class Treinamento : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual DateTime DataCriacao { get; set; }
        public virtual Programa Programa { get; set; }
        public virtual DateTime DataRealizacao { get; set; }
        public virtual Funcionario Responsavel { get; set; }
        public virtual string Local { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual List<Arquivo> Anexos { get; set; }
        public virtual List<Pessoa> Participantes { get; set; }

        protected Treinamento()
        {
        }

        public Treinamento(
            Programa programa, DateTime dataRealizacao, Funcionario funcionario, string local,
            string titulo, string descricao)
        {
            DataCriacao = SystemTime.Now;
            Programa = programa;
            DataRealizacao = dataRealizacao;
            Responsavel = funcionario;
            Local = local;
            Titulo = titulo;
            Descricao = descricao;
            Participantes = new List<Pessoa>();
            Anexos = new List<Arquivo>();
            Validar();
        }

        protected override sealed void Validar()
        {
            if (Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioTreinamento.DeveTerUmPrograma);
            NotificarSeHouverAlgumErro();
        }

        public void AdicionarParticipante(Pessoa participante)
        {
            Participantes.Add(participante);
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
}
