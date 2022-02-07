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
        private readonly ILogger<HomeController> _logger;
        private readonly IGetInTouchService _getInTouchService;
        private readonly IWebHostEnvironment _hostingEnvironment;
      

        public HomeController(ILogger<HomeController> logger, IGetInTouchService getInTouchService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _getInTouchService = getInTouchService;
            _hostingEnvironment = hostingEnvironment;
          
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
      
        /// <summary>
        /// Default Action of the Home Cotroller
        /// </summary>
        /// <returns></returns>
       

        /// <summary>
        /// UI Shows the Various Plans and respective Prices
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Getintouch(EmailModel emailmodel)
        {

            if (ModelState.IsValid)
            {
                var getbussinessModel = new Business.Core.Model.BeautyCareService.EmailModel
                {
                    Name = emailmodel.Name,
                    Body = emailmodel.Body,
                    EmailTo = emailmodel.EmailTo,
                    Subject = emailmodel.Subject
                  
            };
                _getInTouchService.Add(getbussinessModel);
                ViewBag.Message = "Email Sent Successfully";

            }

        
                
         
            return  RedirectToAction("Index");
        }



    }
}
