using System;
using Integra.Dominio.Base;

namespace Integra.Dominio
{
    public class Arquivo : EntidadeBase<int>
    {
        public virtual string Descricao { get; private set; }
        public virtual string Nome { get; private set; }
        public virtual DateTime DataDeUpload { get; private set; }

        protected Arquivo() { }

        public Arquivo(string descricao, string nome, DateTime dataDeUpload)
        {
            Descricao = descricao;
            Nome = nome;
            DataDeUpload = dataDeUpload;
            Validar();
        }

        protected override sealed void Validar()
        {
            NotificarSeHouverAlgumErro();
        }
    }
}
