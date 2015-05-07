using System;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class FaturaServico
    {
        private readonly IFaturaRepositorio _faturaRepositorio;

        public FaturaServico(IFaturaRepositorio faturaRepositorio)
        {
            _faturaRepositorio = faturaRepositorio;
        }

        public Fatura AdicionarFatura(Programa programa, string descricao, TipoDaFatura tipo, StatusDaFatura status, TipoDeDocumento tipoDeDocumento
            , decimal valor, string numeroDoDocumento, DateTime data)
        {
            var fatura = new Fatura(programa)
                             {
                                 Descricao = descricao,
                                 Tipo = tipo,
                                 Documento = tipoDeDocumento,
                                 Data = data,
                                 NumeroDoDocumento = numeroDoDocumento,
                                 Status = status,
                                 Valor = valor
                             };

            _faturaRepositorio.Adicionar(fatura);
            return fatura;
        }

        public Fatura AlterarFatura(Fatura fatura, string descricao, TipoDaFatura tipo, TipoDeDocumento tipoDeDocumento, DateTime data, 
            string numeroDoDocumento, StatusDaFatura status, decimal valor)
        {
            fatura.Descricao = descricao;
            fatura.Tipo = tipo;
            fatura.Documento = tipoDeDocumento;
            fatura.Data = data;
            fatura.NumeroDoDocumento = numeroDoDocumento;
            fatura.Status = status;
            fatura.Valor = valor;
            _faturaRepositorio.Atualizar(fatura);
            return fatura;
        }
    }
}