using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace JourneyEquip.Services.EmailService.Send
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _config;

        public SendEmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("MailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("MailHost").Value, 587,MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("MailUserName").Value,_config.GetSection("MailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);              }
               
    }
}