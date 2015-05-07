using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.ServicosContratados;
using System;

namespace Integra.Dominio
{
    public sealed class ServicosContratados : EntidadeBase<int>, IRaizDeAgregacao
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
        public Programa Programa { get; set; }
        public DateTime DataContratacao { get; set; }
        public DateTime DataDeCriacao { get; set; }

        public ServicosContratados() { }

        public ServicosContratados(Programa programa)
        {
            Programa = programa;
            Validar();
        } 

        protected override sealed void Validar()
        {
            if (Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioServicosContratados.DeveTerUmPrograma);
            NotificarSeHouverAlgumErro();
        }
    }
}
