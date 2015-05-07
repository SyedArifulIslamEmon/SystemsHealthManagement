using System;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class Infusao : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Clinica Clinica { get; set; }
        public virtual string Localizador { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DataInfusao { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual StatusDaInfusao StatusDaInfusao { get; set; }
        public virtual Funcionario Responsavel { get; set; }
        public virtual Programa Programa { get; set; }
        public virtual string NomePaciente { get; set; }
        public virtual string Dosagem { get; set; }
        public virtual string Ampola { get; set; }
        public virtual string Lote { get; set; }

        protected Infusao() { }

        public Infusao(Clinica clinica, string localizador, string cpf, DateTime dataInfusao, DateTime dataCadastro, StatusDaInfusao statusDaInfusao, Funcionario responsavel, Programa programa)
        {
            Clinica = clinica;
            Localizador = localizador;
            Cpf = cpf;
            DataInfusao = dataInfusao;
            DataCadastro = dataCadastro;
            StatusDaInfusao = statusDaInfusao;
            Responsavel = responsavel;
            Programa = programa;

            Validar();
        }

        protected override void Validar()
        {
            NotificarSeHouverAlgumErro();
        }

        public void Glosar()
        {
            StatusDaInfusao = StatusDaInfusao.Glosado;
        }

        public void EmAberto()
        {
            StatusDaInfusao = StatusDaInfusao.Aberto;
        }

        public void Pagar()
        {
            if (StatusDaInfusao == StatusDaInfusao.Aberto)
                StatusDaInfusao = StatusDaInfusao.Pago;
        }

        public decimal Multa()
        {
            if (DataInfusao.AddMonths(2) < SystemTime.Now)
                return Clinica.ValorDeInfusao * (decimal)0.10;
            return 0;
        }
    }

    public enum StatusDaInfusao
    {
        [StringValue("Pendente")]
        Pendente,
        [StringValue("Aberto")]
        Aberto,
        [StringValue("Pago")]
        Pago,
        [StringValue("Estornado")]
        Estornado,
        [StringValue("Glosado")]
        Glosado,
        [StringValue("Cancelado")]
        Cancelado
    }
}
