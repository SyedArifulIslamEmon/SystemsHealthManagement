namespace Integra.Dominio
{
    public class RelatorioRitalinaporFase
    {
        public int Ordem { get; set; }
        public string Medicamento { get; set; }
        public int Crianca { get; set; }
        public double Crianca_Percentual { get; set; }
        public int Adolescente { get; set; }
        public double Adolescente_Percentual { get; set; }
        public int Adulto { get; set; }
        public double Adulto_Percentual { get; set; }
        public int Total { get; set; }
    }
}
