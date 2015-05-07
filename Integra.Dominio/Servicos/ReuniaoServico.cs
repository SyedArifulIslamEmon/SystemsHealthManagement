using System;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class ReuniaoServico
    {
        private readonly IReuniaoRepositorio _reuniaoRepositorio;

        public ReuniaoServico(IReuniaoRepositorio reuniaoRepositorio)
        {
            _reuniaoRepositorio = reuniaoRepositorio;
        }

        public Reuniao AdicionarReuniao(Programa programa, Funcionario representante,
            string local, string assunto, DateTime realizacao, StatusDaReunicao status)
        {
            var reuniao = new Reuniao(programa, representante, local, assunto, realizacao, status);
            _reuniaoRepositorio.Adicionar(reuniao);
            return reuniao;
        }
    }
}