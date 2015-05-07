namespace Integra.Dominio
{
    public class RelatorioOmnitropeVisita
    {
        public string Programa { get; set; }
        public string Data_Solicitacao { get; set; }
        public string Data_Contato_Enf { get; set; }
        public string Tipo_Visita { get; set; }
        public string Paciente { get; set; }

        public string Data_Entrada_Programa { get; set; }
        public string Bairro_Paciente { get; set; }
        public string Cidade_Paciente { get; set; }
        public string UF_Paciente { get; set; }
        public string Medico { get; set; }

        public string Enfermeira { get; set; }
        public string Bairro_Enfermeira { get; set; }
        public string Cidade_Enfermeira { get; set; }
        public string UF_Enfermeira { get; set; }
        public string KM_Visita { get; set; }

        public string Data_Agendamento { get; set; }
        public string Status_Visita { get; set; }
        public string Nota_Visita { get; set; }
        public string Obs_Agendamento { get; set; }
        public string Obs_Pesquisa { get; set; }
    }
}