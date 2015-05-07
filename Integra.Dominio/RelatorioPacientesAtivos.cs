namespace Integra.Dominio
{
    public class RelatorioPacientesAtivos
    {
        public string Ifx { get; set; }
        public string FaixaEtaria { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Doenca { get; set; }
        public string Medico { get; set; }
        public string Especialidade { get; set; }
        public int QtdeInfusoes { get; set; }
        public int QtdeEssencial { get; set; }
        public int QtdeInicioTratamentos { get; set; }
    }
}
