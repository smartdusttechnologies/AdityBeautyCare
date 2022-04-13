using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    /// <summary>
    /// Implimenting IEmailService through Interface
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
       
        /// <summary>
        /// Establing connection with connection factory
        /// </summary>
        /// <param name="configuration"></param>
        public EmailService(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
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

            //Read other values from Appsetting .Json 
            string mailLogoImage = _configuration["AditiGITMail:LogoImage"];
            string mailBodyImage = _configuration["AditiGITMail:BodyImage"];
            string mailContactMobile = _configuration["AditiContact:Mobile"];
            string mailContactMailId = _configuration["AditiContact:emailId"];
            string gITUserMail = _configuration["GetInTouch:UserTemplet"];
            
            //Read EmailAddress From User Table
            using (MailMessage mm = new MailMessage(fromAddress, emailModel.EmailTo))
            {
                mm.Subject = emailModel.Subject;
                mm.Body = CreateBody() ;
                mm.Body = mm.Body.Replace("*name*", emailModel.Name);
                mm.Body = mm.Body.Replace("*Mobile*", mailContactMobile);
                mm.Body = mm.Body.Replace("*emailid*", mailContactMailId);
                mm.Body = mm.Body.Replace("*LogoLink*", mailLogoImage);
                mm.Body = mm.Body.Replace("*BodyImageLink*", mailBodyImage);

                //foreach (var item in emailModel.Bcc)
                //{
                //    mm.Bcc.Add(new MailAddress(item));
                //}
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
        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["GetInTouch:UserTemplet"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
       
        public bool Sendemailadmin(EmailModel emailModel)
        {
            //Read SMTP settings from AppSettings.json.
            string host = _configuration["Smtp:Server"];
            int port = int.Parse(_configuration["Smtp:Port"]);
            string fromAddress = _configuration["Smtp:FromAddress"];
            string userName = _configuration["Smtp:UserName"];
            string password = _configuration["Smtp:Password"];

            //Read other values from Appsetting .Json 
            string mailLogoImage = _configuration["AditiGITMail:LogoImage"];
            string mailBodyImage = _configuration["AditiGITMail:BodyImage"];
            string mailContactMobile = _configuration["AditiContact:Mobile"];
            string mailContactMailId = _configuration["AditiContact:emailId"];
            string gITUserMail = _configuration["GetInTouch:UserTemplet"];

            

            //Read EmailAddress From User Table
            using (MailMessage np = new MailMessage())
            {
                np.From = new MailAddress(fromAddress);
                foreach (var item in emailModel.Bcc)
                {
                    np.To.Add(new MailAddress(item));
                }
                
                np.Subject = emailModel.Subject;
                np.Body = CreateBodyAdmin();
                np.Body = np.Body.Replace("*Name*", emailModel.Name);
                np.Body = np.Body.Replace("Emailid*", emailModel.EmailTo);
                np.Body = np.Body.Replace("*Subject*", emailModel.Subject);
                np.Body = np.Body.Replace("*Message*", emailModel.Message);
                np.Body = np.Body.Replace("*BodyImageLink*", mailBodyImage);
                np.Body = np.Body.Replace("*LogoLink*", mailLogoImage);
                np.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = port;
                    smtp.Send(np);
                }
            }
            return true;
        }
                private string CreateBodyAdmin()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["GetInTouch:AdminMail"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
    }
}
