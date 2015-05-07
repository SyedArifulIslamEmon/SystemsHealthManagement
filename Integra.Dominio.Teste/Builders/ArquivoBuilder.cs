using System;
using Integra.Dominio.Base;

namespace Integra.Dominio.Teste.Builders
{
    public class ArquivoBuilder
    {
        private readonly string _descricao;
        private readonly string _nome;
        private readonly DateTime _dataDeUpload;

        private ArquivoBuilder()
        {
            _descricao = "Uma descricao";
            _nome = "arquivo.txt";
            _dataDeUpload = SystemTime.Now;
        }

        public static ArquivoBuilder DadoUmArquivo()
        {
            return new ArquivoBuilder();
        }

        public Arquivo Build()
        {
            return new Arquivo(_descricao, _nome, _dataDeUpload);
        }
    }
}