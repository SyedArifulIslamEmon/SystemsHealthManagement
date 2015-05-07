using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarAnexoTreinamentoViewModel
    {
        public List<Arquivo> Anexos { get; set; }

        public int CodigoDoTreinamento { get; set; }
    }
}