using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integra.Dominio
{
    public class RelatorioEspecialidadeMedica
    {
        public string DescEspecialidade { get; set; }
        public int QtdeMedico { get; set; }
        public int QtdePacienteUltimoMes { get; set; }
        public int QtdePaciente { get; set; }
    }
}
