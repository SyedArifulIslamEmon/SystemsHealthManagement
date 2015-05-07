using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens;
using Integra.ServicosDeAplicacao.Mensagens.Faturamento;
using System.Linq;

namespace Integra.ServicosDeAplicacao
{
    public class FaturamentoServicoDeAplicacao
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClinicaRepositorio _clinicaRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IInfusaoRepositorio _infusaoRepositorio;
        private readonly INotaFiscalRepositorio _notaFiscalRepositorio;
        private readonly RepositorioDeArquivos _repositorioDeArquivos;
        private readonly IProgramaRepositorio _programaRepositorio;

        public FaturamentoServicoDeAplicacao(IUnitOfWork unitOfWork, IProgramaRepositorio programaRepositorio, IClinicaRepositorio clinicaRepositorio, IFuncionarioRepositorio funcionarioRepositorio,
            IInfusaoRepositorio infusaoRepositorio, INotaFiscalRepositorio notaFiscalRepositorio, RepositorioDeArquivos repositorioDeArquivos)
        {
            _unitOfWork = unitOfWork;
            _clinicaRepositorio = clinicaRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _infusaoRepositorio = infusaoRepositorio;
            _notaFiscalRepositorio = notaFiscalRepositorio;
            _repositorioDeArquivos = repositorioDeArquivos;
            _programaRepositorio = programaRepositorio;
        }

        public NovaNotaResposta NovaNota(NovaNotaRequisicao requisicao)
        {
            int tentativa = 0;
            bool sucesso = false;
            DateTime dataUpload = SystemTime.Now;
            var nota = NotaFiscal(requisicao, dataUpload);
            _notaFiscalRepositorio.Adicionar(nota);
            while (sucesso != true)
            {
                tentativa++;
                try
                {
                    _unitOfWork.Commit();
                    sucesso = true;
                }
                catch (Exception ex)
                {
                    if (tentativa >= 5)
                    {
                        throw ex;
                    }
                }
            }

            _repositorioDeArquivos.ArmazenarArquivo(requisicao.Arquivo, requisicao.NomeDoArquivo, dataUpload);
            return new NovaNotaResposta { Sucesso = true };
        }

        private NotaFiscal NotaFiscal(NovaNotaRequisicao requisicao, DateTime dataUpload)
        {
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
            var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
            var nota = new NotaFiscal
                           {
                               Clinica = clinica,
                               Responsavel = responsavel,
                               Valor = requisicao.Valor,
                               Numero = requisicao.Numero,
                               Data = requisicao.Data,
                               DataRecebimento = requisicao.DataRecebimento,
                               Arquivo = new Arquivo(requisicao.DescricaoDoArquivo, requisicao.NomeDoArquivo, dataUpload),
                               Programa = programa
                           };


            foreach (var infusaoAssociar in requisicao.Infusoes)
            {
                var infusao = _infusaoRepositorio.ObterPor(infusaoAssociar.Codigo);

                infusao.EmAberto();
                if (infusaoAssociar.Glosar)
                    infusao.Glosar();

                nota.Infusoes.Add(infusao);
            }
            return nota;
        }

        private NotaFiscal NotaFiscalDevolucao(NovaNotaRequisicao requisicao, DateTime dataUpload)
        {
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
            var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
            var nota = new NotaFiscal
            {
                Clinica = clinica,
                Responsavel = responsavel,
                Valor = requisicao.Valor,
                Numero = requisicao.Numero,
                Data = requisicao.Data,
                DataRecebimento = requisicao.DataRecebimento,
                Arquivo = new Arquivo(requisicao.DescricaoDoArquivo, requisicao.NomeDoArquivo, dataUpload),
                Programa = programa
            };

            //IMPLEMENTAR VINCULO NF DEVOLVIDA COM INFUSAO.

            //foreach (var infusaoAssociar in requisicao.Infusoes)
            //{
            //    var infusao = _infusaoRepositorio.ObterPor(infusaoAssociar.Codigo);

            //    infusao.EmAberto();
            //    if (infusaoAssociar.Glosar)
            //        infusao.Glosar();

            //    nota.Infusoes.Add(infusao);
            //}

            return nota;
        }

        public PagarNotaFiscalResposta PagarNotaFiscal(PagarNotaFiscalRequisicao requisicao)
        {
            var nota = _notaFiscalRepositorio.ObterPor(requisicao.CodigoDaNota);
            var dataUpload = SystemTime.Now;
            var pagamento = new Pagamento
                                {
                                    Comprovante = new Arquivo(requisicao.DescricaoDoComprovante, requisicao.NomeDoComprovante, dataUpload),
                                    Observacao = requisicao.Observacao,
                                    DataPagamento = requisicao.DataPagamento
                                };
            _repositorioDeArquivos.ArmazenarArquivo(requisicao.Comprovante, requisicao.NomeDoComprovante, dataUpload);
            nota.Pagar(pagamento);
            _unitOfWork.Commit();
            return new PagarNotaFiscalResposta() { Sucesso = true };
        }

        public EstornarNotaFiscalResposta EstornarNotaFiscal(EstornarNotaFiscalRequisicao requisicao)
        {
            var nota = _notaFiscalRepositorio.ObterPor(requisicao.CodigoDaNota);
            nota.Estornar(new Estorno { Observacao = requisicao.Observacao });
            foreach (var infusao in nota.Infusoes)
            {
                infusao.StatusDaInfusao = StatusDaInfusao.Pendente;
            }
            nota.Infusoes.Clear();
            _unitOfWork.Commit();
            return new EstornarNotaFiscalResposta() { Sucesso = true };
        }

        public DevolverNotaResposta DevolverNotaFiscal(DevolverNotaRequisicao requisicao)
        {
            var data = SystemTime.Now;
            var nota = NotaFiscalDevolucao(requisicao, data);
            nota.Devolver(requisicao.Motivo, requisicao.TipoDeDevolucao);

            _repositorioDeArquivos.ArmazenarArquivo(requisicao.Arquivo, requisicao.NomeDoArquivo, data);
            _notaFiscalRepositorio.Adicionar(nota);
            _unitOfWork.Commit();
            return new DevolverNotaResposta { Sucesso = true };
        }

        public ObterArquivoDaNotaFiscalResposta ObterArquivoDaNotaFiscal(ObterArquivoDaNotaFiscalRequisicao requisicao)
        {
            var resposta = new ObterArquivoDaNotaFiscalResposta();
            try
            {
                var nota = _notaFiscalRepositorio.ObterPor(requisicao.CodigoDaNota);
                resposta.Nota = nota;
                resposta.Arquivo = _repositorioDeArquivos.ObterArquivo(nota.Arquivo.Nome, nota.Arquivo.DataDeUpload);
                resposta.Sucesso = true;
            }
            catch (Exception)
            { }
            return resposta;
        }

        public ObterComprovanteResposta ObterComprovante(ObterComprovanteRequisicao requisicao)
        {
            var resposta = new ObterComprovanteResposta();
            try
            {
                var nota = _notaFiscalRepositorio.ObterPor(requisicao.CodigoDaNota);
                resposta.Nota = nota;
                resposta.Arquivo = _repositorioDeArquivos.ObterArquivo(nota.Pagamento.Comprovante.Nome, nota.Pagamento.Comprovante.DataDeUpload);
                resposta.Sucesso = true;
            }
            catch (Exception)
            { }
            return resposta;
        }

        public ObterConsultaPreviaNoMesResposta ObterConsultaPreviaNoMes(int mes, int ano, Programa programa)
        {

            //var infusoes = _infusaoRepositorio.ObterTodos();
            var infusoes = _infusaoRepositorio.ObterTodasNoMes(mes, ano, programa);
            var totalPorClinica = from infusao in infusoes
                                  group infusao by infusao.Clinica.Codigo
                                      into i
                                      select new TotalPorClinica
                                      {
                                          QuantidadeDeInfusoes = i.Count(),
                                          ValorDasInfusoes = i.Sum(it => it.Clinica.ValorDeInfusao),
                                          NomeDaClinica = i.First().Clinica.Nome,
                                          CodigoDaClinica = i.First().Clinica.Codigo
                                      };


            //var notas = _notaFiscalRepositorio.ObterTodasNoMes(mes, ano, programa);
            //var totalPorClinica = from nota in notas
            //                      group nota by nota.Clinica.Codigo
            //                          into g
            //                          select new TotalPorClinica
            //                                     {
            //                                         QuantidadeDeInfusoes = g.Sum(it => it.Infusoes.Count),
            //                                         ValorDasInfusoes = g.Sum(it => it.Valor),
            //                                         NomeDaClinica = g.First().Clinica.Nome,
            //                                         CodigoDaClinica = g.First().Clinica.Codigo
            //                                     };

            return new ObterConsultaPreviaNoMesResposta
                       {
                           Clinicas = totalPorClinica,
                           Sucesso = true
                       };
        }

        public RespostaBase EnviarPreviaPorEmail(int idClinica, int mes, int ano, string email)
        {
            var clinica = _clinicaRepositorio.ObterPor(idClinica);
            var infusoes = _infusaoRepositorio.ObterTodasInfusoesDaClinicaNoMes(idClinica, mes, ano);

            var html = new StringBuilder();
            html.Append("Segue abaixo a prévia de faturamento referente ao mês: <b>" + new DateTime(ano, mes == 13 ? 1 : mes, 1).ToString("MM/yyyy") + "</b></br></br>");
            html.Append("Clínica: <b>" + clinica.Nome + "</b></br></br>");

            html.Append("<table style='border-spacing:0px;border: 1px solid #dddddd;position: relative;display: inline-block;margin-right: 4px;color: #555;content: '\f0dc';font-weight: normal;font-size: 13px;font-family: FontAwesome;'><thead>");
            html.Append("<tr style='background-color:lightgray'><th style='color: #307ECC;'>Data da infusão</th><th style='color: #307ECC;'>Paciente</th><th style='color: #307ECC;'>Localizador</th><th style='color: #307ECC;'>Lote</th><th style='color: #307ECC;'>Valor</th></tr>");
            html.Append("</thead><tbody>");

            foreach (var infusao in infusoes)
            {
                html.Append("<tr style='background-color:lightblue'>");
                html.Append("<td>" + infusao.DataInfusao.ToString("dd/MM/yyyy") + "</td>");
                html.Append("<td>" + (infusao.NomePaciente.Split('|').Length - 1 > 0 ? infusao.NomePaciente.Split('|')[0] : infusao.NomePaciente) + "</td>");
                html.Append("<td style='text-align: center;'>" + infusao.Localizador + "</td>");
                html.Append("<td>" + infusao.Lote + "</td>");
                html.Append("<td>" + infusao.Clinica.ValorDeInfusao + "</td>");
                html.Append("</tr>");
            }
            html.Append("</tbody></table>");
            html.Append("</br>");

            html.Append("Quantidade: " + infusoes.Count().ToString(CultureInfo.InvariantCulture));
            html.Append("</br>");
            html.Append("Total: R$ " + string.Format("{0:#.00}", Convert.ToDecimal(infusoes.Sum(inf => inf.Clinica.ValorDeInfusao).ToString(CultureInfo.InvariantCulture)) / 100));
            html.Append("</br></br>");

            html.Append("<ul style='list-style-type: circle'>");
            html.Append("<li>Nota Fiscal deverá ser encaminhada para o Programa Essencial” através do e-mail programaessencial@integramedical.com.br ou via correios “junto com as <b>AUTORIZAÇÕES DE INFUSÃO</b>” </br>");
            html.Append("até o   dia 10 de cada mês para a ÍNTEGRA MEDICAL – A/C PROGRAMA ESSENCIAL.</li>");
            html.Append("<br>");
            html.Append("<li><b style='color:red;'>Ressaltamos para que o pgamento seja realizado, será obrigatório o envio das AUTORIZAÇÕES DE INFUSÃO. Caso não sejam enviadas, o Programa Essencial poderá cancelar o pagamento, até que seja enviado o documento, conforme contrato </br>vigente com a clínica.</b></li>");
            html.Append("</ul>");

            html.Append("</br>");
            html.Append("<img src='http://www.integrawebservice.com.br/Site_PainelDeControle/Content/images/LogoEssencial.fw.png' />");

            var servicoDeEmail = new ServicoDeEmail();
            servicoDeEmail.EnviarEmailInfusao(email, "Programa Essencial - Prévia de Faturamento", html.ToString());
            return new RespostaBase { Sucesso = true };
        }
    }

    public class TotalPorClinica
    {
        public int QuantidadeDeInfusoes { get; set; }

        public decimal ValorDasInfusoes { get; set; }

        public string NomeDaClinica { get; set; }

        public int CodigoDaClinica { get; set; }
    }

    public class ObterConsultaPreviaNoMesResposta : RespostaBase
    {
        public IEnumerable<TotalPorClinica> Clinicas { get; set; }
    }
}
