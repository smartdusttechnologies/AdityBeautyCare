using Microsoft.AspNetCore.Mvc;
using AditiBeautyCare.Web.UI.Models;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;


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
        private readonly IEmailService _emailservice;

        /// <summary>
        /// Declaring the variables for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="beautyCareService"></param>
        /// <param name="hostingEnvironment"></param>
        public HomeController(ILogger<HomeController> logger, IGetInTouchService getInTouchService, IWebHostEnvironment hostingEnvironment, IEmailService emailservice)
        {
            _logger = logger;
            _getInTouchService = getInTouchService;
            _hostingEnvironment = hostingEnvironment;
            _emailservice = emailservice;
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
                var emailModel = new Business.Core.Model.BeautyCareService.EmailModel
                {
                    Name = emailmodel.Name,
                    Message = emailmodel.Message,
                    EmailTo = emailmodel.EmailTo,
                    Subject = emailmodel.Subject
                };

                var result = _getInTouchService.Add(emailModel);
                if (result.IsSuccessful)
                {
                    var isemailsendsuccessfully = _emailservice.Sendemail(emailModel);
                    if (isemailsendsuccessfully)
                    {
                        ViewBag.Message = "Email Sent Successfully";
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Unable to Process the request. Please contact administarator";
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

    }
}
