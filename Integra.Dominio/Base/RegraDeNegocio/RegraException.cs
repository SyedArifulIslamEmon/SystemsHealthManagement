using System;
using System.Collections.Generic;

namespace Integra.Dominio.Base.RegraDeNegocio
{
    public class RegraException : Exception
    {
        public List<RegraDeNegocioBase> Erros { get; private set; }

        public RegraException()
        {
            Erros = new List<RegraDeNegocioBase>();
        }

        internal void AdicionarErroPara(RegraDeNegocioBase regraDeNegocio)
        {
            Erros.Add(regraDeNegocio);
        }
    }
}