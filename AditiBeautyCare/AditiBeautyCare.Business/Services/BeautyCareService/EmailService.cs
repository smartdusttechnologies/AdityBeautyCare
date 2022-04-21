using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    /// <summary>
    /// Implimenting IEmailService through Interface
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Establing connection with connection factory
        /// </summary>
        /// <param name="configuration"></param>
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Sending mail
        /// </summary>
        /// <param name="emailModel"></param>
        /// <returns></returns>
        public bool Sendemail(EmailModel emailModel)
        {
            //Read SMTP settings from AppSettings.json.
            string host = _configuration["Smtp:Server"];
            int port = int.Parse(_configuration["Smtp:Port"]);
            string fromAddress = _configuration["Smtp:FromAddress"];
            string userName = _configuration["Smtp:UserName"];
            string password = _configuration["Smtp:Password"];

            using (MailMessage mm = new MailMessage(fromAddress, emailModel.EmailTo))
            {
                mm.Subject = emailModel.Subject;
                mm.Body = emailModel.Message;
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = port;
                    smtp.Send(mm);
                }
            }
            return true;
        }
    }
}
