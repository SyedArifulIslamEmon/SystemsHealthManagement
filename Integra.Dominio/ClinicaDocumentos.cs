using System;
using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;


namespace Integra.Dominio
{
    public class ClinicaDocumentos : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Funcionario Responsavel { get; set; }
        public virtual DateTime DataDeUpload { get; private set; }
        public virtual TipoDocumentoDaClinica TipoDocumento { get; private set; }
        public virtual string Descricao { get; private set; }
        public virtual string Nome { get; private set; }
        public virtual DateTime DataDeVencimento { get; set; }
        public virtual DocumentoStatus StatusDocumento { get; set; }
        public string ClinicaNome { get; set; }
        public int ClinicaCodigo { get; set; }


        public ClinicaDocumentos() { }

        public ClinicaDocumentos(Funcionario funcionario, DateTime dataDeUpload, TipoDocumentoDaClinica tipoDocumento, string descricao, string nome, DateTime dataVencimento, DocumentoStatus statusDocumento)
        {
            Responsavel = funcionario;
            DataDeUpload = dataDeUpload;
            TipoDocumento = tipoDocumento;
            Descricao = descricao;
            Nome = nome;
            DataDeVencimento = dataVencimento;
            StatusDocumento = statusDocumento;
            Validar();
        }

        protected override sealed void Validar()
        {
            NotificarSeHouverAlgumErro();
        }
    }

    public enum TipoDocumentoDaClinica
    {
        [StringValue("Contrato Íntegra")]
        ContratoIntegra,
        [StringValue("Alvará")]
        Alvara,
        [StringValue("Contrato Social")]
        ContratoSocial,
        [StringValue("Vigilância Sanitária")]
        VigilanciaSanitaria,
        [StringValue("Regime Interno Município")]
        RegimeInterno,
        [StringValue("Documento Responsável Clínica")]
        DocRespClinica,
        [StringValue("Documento Responsável Técnico")]
        DocRespTecnico,
        [StringValue("Outros Documentos")]
        OutrosDocumentos,
        [StringValue("Certificado Médico")]
        CertificadoMedico,
        [StringValue("Certificado Enfermeiro")]
        CertificadoEnfermeiro
    }


    public enum DocumentoStatus
    {
        [StringValue("Inativo")]
        Inativo,
        [StringValue("Ativo")]
        Ativo

    }
}
