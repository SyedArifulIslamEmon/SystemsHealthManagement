using System;
using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Clinica;

namespace Integra.Dominio
{
    public class Clinica : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Programa Programa { get; private set; }
        public virtual Funcionario Responsavel { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public virtual Representante Representante { get; set; }
        public virtual Gerente Gerente { get; set; }
        public virtual RepresentanteRegional RepresentanteRegional { get; set; }
        public string Observacoes { get; set; }
        public virtual List<ClinicaDocumentos> Documentos { get; private set; }
        public virtual DateTime DataCadastro { get; private set; }
        public virtual StatusDaClinica Status { get; set; }
        public virtual bool IndicarNovosPacientes { get; set; }
        public virtual string Telefone2 { get; set; }
        public virtual string Telefone3 { get; set; }
        public virtual Decimal ValorDeInfusao { get; set; }
        public string Email { get; set; }
        public string Bairro { get; set; }

        protected Clinica() { }

        public Clinica(Programa programa, Funcionario responsavel, string nome, string razaoSocial, string cnpj, string inscricaoEstadual, string endereco, 
            string cidade, string uf, string telefone, string contato, string observacoes, StatusDaClinica status, string email, decimal valorDeInfusao, string bairro)
        {
            Programa = programa;
            Responsavel = responsavel;
            
            Nome = nome;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            Endereco = endereco;
            Cidade = cidade;
            Uf = uf;
            Telefone = telefone;
            Contato = contato;
            Observacoes = observacoes;
            ValorDeInfusao = valorDeInfusao;

            Documentos = new List<ClinicaDocumentos>();
            DataCadastro = SystemTime.Now;
            Status = status;

            Email = email;

            Bairro = bairro;

            Validar();
        }

        protected override void Validar()
        {
            if (Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioClinica.DeveTerUmPrograma);
            NotificarSeHouverAlgumErro();
        }

        public void AdicionarDocumento(ClinicaDocumentos documento)
        {
            Documentos.Add(documento);
        }

        public void RemoverDocumento(ClinicaDocumentos documento)
        {
            Documentos.Remove(documento);
        }
    }

    public enum StatusDaClinica
    {
        [StringValue("Ativo")]
        Ativo,
        [StringValue("Inativo")]
        Inativo,
        [StringValue("Aprovação")]
        Aprovacao,
        [StringValue("Aguardando Doc.")]
        Aguardando
    }
}
