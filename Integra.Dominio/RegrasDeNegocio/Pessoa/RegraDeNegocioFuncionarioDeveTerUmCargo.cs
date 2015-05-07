using Integra.Dominio.Base.RegraDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integra.Dominio.RegrasDeNegocio.Pessoa
{
    public class RegraDeNegocioFuncionarioDeveTerUmCargo: RegraDeNegocioBase
    {
        public RegraDeNegocioFuncionarioDeveTerUmCargo():base("Uma funcionario deve ter um departamento.")
        {

        }
    }
}
