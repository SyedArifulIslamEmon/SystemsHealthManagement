namespace Integra.Dominio
{
    public class RelatorioQuantidadePacientesAtivos
    {
        public string Data { get; set; }
        public string Medico { get; set; }
        public string EstadoMedico { get; set; }
        public string CidadeMedico { get; set; }
        public int QtdePacientesAtivos { get; set; }
        public int QtdeContato { get; set; }
        public int QtdeContatoSemLocalizador { get; set; }
        public int QtdeContatoComLocalizador { get; set; }
    }
}
