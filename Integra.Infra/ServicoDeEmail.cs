using System;
using System.Net.Mail;

namespace Integra.Infra
{
    public class ServicoDeEmail
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _to;

        public ServicoDeEmail()
        {
            _smtpClient = new SmtpClient();
            _to = string.Empty;
        }

        public ServicoDeEmail(string to)
        {
            _smtpClient = new SmtpClient();
            _to = to;
        }

        public bool EnviarEmail(string assunto, string mensagem)
        {
            return EnviarEmail(_to, assunto, mensagem);
        }

        public bool EnviarEmail(string to, string assunto, string mensagem)
        {
            var message = new MailMessage();
            message.To.Add(to);
            message.Subject = assunto;
            message.Body = mensagem;
            message.IsBodyHtml = true;
            try
            {
                _smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EnviarEmailInfusao(string to, string assunto, string mensagem)
        {
            var message = new MailMessage();
            message.To.Add(to);
            message.CC.Add("selma.andrade@integramedical.com.br");
            message.Subject = assunto;
            message.Body = mensagem;
            message.IsBodyHtml = true;
            try
            {
                _smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
