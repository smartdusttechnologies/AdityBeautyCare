using Microsoft.AspNetCore.Mvc;
using AditiBeautyCare.Web.UI.Models;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using AditiBeautyCare.Web.UI.Controllers;


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

        /// <summary>
        /// Declaring the variables for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="beautyCareService"></param>
        /// <param name="hostingEnvironment"></param>
        public HomeController(ILogger<HomeController> logger, IGetInTouchService getInTouchService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _getInTouchService = getInTouchService;
            _hostingEnvironment = hostingEnvironment;
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
                var getbussinessModel = new Business.Core.Model.BeautyCareService.EmailModel
                {
                    Name = emailmodel.Name,
                    Body = emailmodel.Message,
                    EmailTo = emailmodel.Email,
                    Subject = emailmodel.Subject   
            };
                _getInTouchService.Add(getbussinessModel);
                ViewBag.Message = "Email Sent Successfully";
            }      
             return  RedirectToAction("Index");
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        
    }
}
