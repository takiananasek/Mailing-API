using ClientApi.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;


namespace ClientApi.Service
{
    public class ApiSmtpClient
    {
        private SmtpServerConfiguration _smtpServerConfiguration;

        public ApiSmtpClient(SmtpServerConfiguration smtpServerConfiguration)
        {
            _smtpServerConfiguration = smtpServerConfiguration;
        }

        public MimeMessage PrepareMessage(EmailData emailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpServerConfiguration.SenderEmail));
            email.To.Add(MailboxAddress.Parse(emailData.EmailAdress));
            email.Subject = emailData.UserId.ToString();
            email.Body = new TextPart(TextFormat.Plain) { Text = emailData.Message };

            return email;

        }

        public void Send(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            smtp.Connect("localhost", _smtpServerConfiguration.Port, SecureSocketOptions.None);

          
            // smtp.Authenticate("[USERNAME]", "[PASSWORD]");
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
