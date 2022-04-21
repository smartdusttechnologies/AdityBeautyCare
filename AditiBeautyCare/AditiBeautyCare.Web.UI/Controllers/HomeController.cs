using Microsoft.AspNetCore.Mvc;
using AditiBeautyCare.Web.UI.Models;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using AditiBeautyCare.Web.UI.Controllers;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NPOI.SS.Formula.Functions;
using System.Linq;

namespace AditiBeautyCare.Web.UI.Common
{
    /// <summary>
    /// Controllers Loads the Home Page Application
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetInTouchService _getInTouchService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;


        /// <summary>
        /// Declaring the variables for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="beautyCareService"></param>
        /// <param name="hostingEnvironment"></param>
        public HomeController(ILogger<HomeController> logger, IGetInTouchService getInTouchService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _logger = logger;
            _getInTouchService = getInTouchService;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }


        /// <summary>
        /// load index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Saving the mail details to database and sending mail to client
        /// </summary>
        /// <param name="emailmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetInTouch(EmailModel emailmodel)
        {
            if (ModelState.IsValid)
            {
                var emailTo = new List<string>();
                emailTo.Add(emailmodel.EmailTo);

                var getbussinessModel = new Business.Core.Model.BeautyCareService.EmailModel
                {
                    Name = emailmodel.Name,
                    Message = emailmodel.Message,
                    Subject = emailmodel.Subject,
                    //List<string> EmailTo = string.Join(",", emailmodel.EmailTo),
                    //List<string> EmailTo = emailmodel.EmailTo.Split(','),ToList();
                    //var readOnlyList = new ReadOnlyCollection<string>(existingList);
                    //var EmailTo = new ReadOnlyCollection<T>(",", emailmodel.EmailTo)
                    //EmailTo = string.Join<string>(',', IEnumerable.string(emailmodel.EmailTo))
                    EmailTo = emailTo
                };

                _getInTouchService.Add(getbussinessModel);
                ViewBag.Message = "Email Sent Successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
