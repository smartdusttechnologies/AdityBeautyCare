using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Http;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    /// <summary>
    /// Implimenting IEmailService through Interface
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IGetInTouchRepository emailmsg;

        /// <summary>
        /// Establing connection with connection factory
        /// </summary>
        /// <param name="configuration"></param>
        public EmailService(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, IGetInTouchRepository getInTouchRepository)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            emailmsg = getInTouchRepository;
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
            string emailto = string.Join(",", emailModel.EmailTo);
            
            //Read EmailAddress From User Table
            using (MailMessage mm = new MailMessage(fromAddress, emailto))
            {
                mm.Subject = emailModel.Subject;
                mm.Body = emailModel.HtmlMsg;
                mm.IsBodyHtml = true;
                
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