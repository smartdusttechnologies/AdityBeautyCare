using AditiBeautyCare.Business.Common;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    /// <summary>
    /// IsampleService is implimenting the services for GetInTouchService
    /// </summary>
    public class GetInTouchService : IGetInTouchService
    {
        private readonly IGetInTouchRepository _getInTouchRepository;
        private readonly IEmailService _emailservice;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        #region public methods
        /// <summary>
        /// implimented getintouchservice interfaces
        /// </summary>
        /// <param name="getInTouchRepository"></param>
        /// <param name="emailservice"></param>
        public GetInTouchService(IGetInTouchRepository getInTouchRepository, IWebHostEnvironment hostingEnvironment, IEmailService emailservice, IUserRepository userRepository, IConfiguration configuration)
        {
            _getInTouchRepository = getInTouchRepository;
            _emailservice = emailservice;
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// implimented getintouchservice  add method interfaces
        /// </summary>
        /// <param name="emailmodel"></param>
        /// <returns></returns>
        public RequestResult<int> Add(EmailModel emailmodel)
        {
            var emailsendTo = _userRepository.Get();

            //Read other values from Appsetting .Json 
            string mailLogoImage = _configuration["AditiGITMail:LogoImage"];
            string mailBodyImage = _configuration["AditiGITMail:BodyImage"];
            string mailContactMobile = _configuration["AditiContact:Mobile"];
            string mailContactMailId = _configuration["AditiContact:emailId"];
            string gITUserMail = _configuration["GetInTouch:UserTemplet"];

            emailmodel.EmailTemplate = _configuration["GetInTouch:UserTemplet"];
            emailmodel.EmailTemplate = _configuration["GetInTouch:AdminMail"];
            emailmodel.LogoImage = _configuration["AditiGITMail:LogoImage"];
            emailmodel.BodyImage = _configuration["AditiGITMail:BodyImage"];
            emailmodel.EmailContact = _configuration["AditiContact:emailId"];
            emailmodel.MobileNumber = _configuration["AditiContact:Mobile"];

            // Building the message for User
            emailmodel.HtmlMsg = CreateBody(emailmodel.EmailTemplate);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*name*", emailmodel.Name);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Subject*", emailmodel.Subject);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Message*", emailmodel.Message);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Mobile*", emailmodel.MobileNumber);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Emailid*", emailmodel.EmailTo.FirstOrDefault());
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*AditiEmailid*", emailmodel.EmailContact);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*LogoLink*", emailmodel.LogoImage);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*BodyImageLink*", emailmodel.BodyImage);

            var isemailsendsuccessfully = _emailservice.Sendemail(emailmodel);
            _getInTouchRepository.Insert(emailmodel);

            //Building the Message for the Admin
            emailmodel.HtmlMsg = CreateBodyAdmin(emailmodel.EmailTemplate);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*name*", emailmodel.Name);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Subject*", emailmodel.Subject);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Message*", emailmodel.Message);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Mobile*", emailmodel.MobileNumber);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*Emailid*", emailmodel.EmailTo.FirstOrDefault());
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*AditiEmailid*", emailmodel.EmailContact);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*LogoLink*", emailmodel.LogoImage);
            emailmodel.HtmlMsg = emailmodel.HtmlMsg.Replace("*BodyImageLink*", emailmodel.BodyImage);

            emailmodel.EmailTo.RemoveAt(0);

            foreach (var item in emailsendTo)
            {
                emailmodel.EmailTo.Add(item);
            }

            var isemailsendsuccessfully1 = _emailservice.Sendemail(emailmodel);

            if (isemailsendsuccessfully)
            {
                //_getInTouchRepository.Insert(emailmodel);
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }

        private string CreateBody(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["GetInTouch:UserTemplet"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
        private string CreateBodyAdmin(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["GetInTouch:AdminMail"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        /// <summary>
        /// implimented getintouchservice interfaces
        /// </summary>
        /// <param name="emailmodel"></param>
        /// <returns></returns>

        //public RequestResult<int> AddCollection(List<GetInTouchModel> mailsend)
        //{
        //    _getInTouchRepository.InsertCollection(mailsend);
        //    return new RequestResult<int>(1);
        //}
        #endregion
    }
}