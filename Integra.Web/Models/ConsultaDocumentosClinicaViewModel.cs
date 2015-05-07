using System;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class ConsultaDocumentosClinicaViewModel
    {
        //public DateTime DataDeUpload { get; set; }
        //public string TipoDocumento { get; set; }
        //public string Descricao { get; set; }
        //public string Nome { get; set; }
        //public DateTime DataDeVencimento { get; set; }
        //public string StatusDocumento { get; set; }
        //public string ClinicaNome { get; set; }
        //public int ClinicaCodigo { get; set; }

        public string ClinicaNome { get; set; }
        public int ClinicaCodigo { get; set; }
        public DateTime DataDeUpload { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public string StatusDocumento { get; set; }
        public string TipoDocumento { get; set; }


        public string ContratoIntegra { get; set; }
        public string Alvara { get; set; }
        public string ContratoSocial { get; set; }
        public string VigilanciaSanitaria { get; set; }
        public string RegimeInterno { get; set; }
        public string DocRespClinica { get; set; }
        public string DocRespTecnico { get; set; }
        public string OutrosDocumentos { get; set; }
        public string CertificadoMedico { get; set; }
        public string CertificadoEnfermeiro { get; set; }

        public DateTime ContratoIntegraData { get; set; }
        public DateTime AlvaraData { get; set; }
        public DateTime ContratoSocialData { get; set; }
        public DateTime VigilanciaSanitariaData { get; set; }
        public DateTime RegimeInternoData { get; set; }
        public DateTime DocRespClinicaData { get; set; }
        public DateTime DocRespTecnicoData { get; set; }
        public DateTime OutrosDocumentosData { get; set; }
        public DateTime CertificadoMedicoData { get; set; }
        public DateTime CertificadoEnfermeiroData { get; set; }
    }
}
