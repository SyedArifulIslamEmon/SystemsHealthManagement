namespace Integra.Dominio
{
    public class RelatorioDesempenhoAcesso
    {
        public string DescTipoFormaAcesso { get; set; }
        public string CodTipoFormaAcesso { get; set; }
        //public string DescFormaAcesso { get; set; }
        //public string CodFormaAcesso { get; set; }
        public string QtdeTratamentosIndicacao { get; set; }
        public string QtdeTratamentosTentativa { get; set; }
        public string QtdeTratamentosSeparado { get; set; }
        public string QtdeTratamentosDocumentacao { get; set; }
        public string QtdeTratamentosAcessoSucesso { get; set; }
        public string QtdeTratamentosNegado { get; set; }
        public string QtdeTratamentosNaoTentara { get; set; }
    }
}
