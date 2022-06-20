using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace JourneyEquip.Services.EmailService.Apply
{
    public class UserApplicationEmailService : IUserApplicationEmailService
    {
        private readonly IConfiguration _config;
        private readonly string _templatePath;

        public UserApplicationEmailService(IConfiguration config, IConfiguration templatePath)
        {
            _config = config;   
            _templatePath = templatePath["Path:Templates"];
        }
        public void UserApplicationEmail(EmailDto request)
        {
            string FullPath = Path.Combine(_templatePath, "UserApplication.html");

             StreamReader str = new StreamReader(FullPath);
            string mailText = str.ReadToEnd();
            str.Close();
            mailText = mailText.Replace("[userName]", request.UserName).Replace("[userEmail]", request.UserEmail).Replace("[userCountry]", request.UserCountry);
            request.Body = mailText;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("MailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("MailHost").Value, 587,MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("MailUserName").Value,_config.GetSection("MailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);       
         }
    }
}