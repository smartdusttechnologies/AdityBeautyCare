using Microsoft.AspNetCore.Mvc;
using System.Net;

using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using AditiBeautyCare.Web.UI.Models;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace AditiBeautyCare.Web.UI.Controllers
{
    /// <summary>
    /// Controllers Loads the Home Page Application
    /// </summary>
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IGetInTouchService _getInTouchService;
        //private readonly IWebHostEnvironment _hostingEnvironment;

        //public HomeController(ILogger<HomeController> logger, IGetInTouchService getInTouchService, IWebHostEnvironment hostingEnvironment)
        //{
        //    _logger = logger;
        //    _getInTouchService = getInTouchService;
        //    _hostingEnvironment = hostingEnvironment;
        //}
        //[HttpGet]
        //public IActionResult Index(int id)
        //{
        //    var EmailUIModel = new Models.EmailModel {Id = id };
        //    return View(EmailUIModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult BookService([Bind] Models.EmailModel mailsend)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var getbussinessModel = new Business.Core.Model.BeautyCareService.GetInTouchModel
        //        {
        //           Name= mailsend.Name,
        //           Body= mailsend.Body,
        //           EmailTo= mailsend.EmailTo,
        //           Subject=mailsend.Subject
        //        };
        //        _getInTouchService.Add(getbussinessModel);

        //    }
        //    return RedirectToAction("Index");
        //}















        /// <summary>
        /// Default Action of the Home Cotroller
        /// </summary>
        /// <returns></returns>

        private IConfiguration Configuration;
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// UI Shows the Various Plans and respective Prices
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Index(EmailModel model)
        {
            //Read SMTP settings from AppSettings.json.
            string host = this.Configuration.GetValue<string>("Smtp:Server");
            int port = this.Configuration.GetValue<int>("Smtp:Port");
            string fromAddress = this.Configuration.GetValue<string>("Smtp:FromAddress");
            string userName = this.Configuration.GetValue<string>("Smtp:UserName");
            string password = this.Configuration.GetValue<string>("Smtp:Password");

            using (MailMessage mm = new MailMessage(fromAddress, model.EmailTo))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;


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
                    ViewBag.Message = "Email Sent Successfully";
                }
            }
            return View();
        }



        public IActionResult PlanPricing()
        {
            return View();
        }

    }
}
