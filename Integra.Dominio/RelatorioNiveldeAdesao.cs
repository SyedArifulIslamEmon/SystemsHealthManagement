namespace Integra.Dominio
{
    public class RelatorioNiveldeAdesao
    {
        public int Ordem { get; set; }
        public string Nome { get; set; }
        public int Total { get; set; }
        public int Alta { get; set; }
        public double Perc_Alta { get; set; }
        public int Media { get; set; }
        public double Perc_Media { get; set; }
        public int Baixa { get; set; }
        public double Perc_Baixa { get; set; }
    }
}