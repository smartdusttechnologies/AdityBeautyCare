using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AditiBeautyCare.Web.UI.Controllers
{
    public class BeautyCareServiceController : Controller
    {
        private readonly ILogger<BeautyCareServiceController> _logger;
        private readonly IBeautyCareService _beautyCareService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public BeautyCareServiceController(ILogger<BeautyCareServiceController> logger, IBeautyCareService beautyCareService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _beautyCareService = beautyCareService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var services = _beautyCareService.GetPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceModel> servicess = new List<UI.Models.BeautyCareService.BeautyCareServiceModel>();
            foreach (var item in services)
            {
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel { Id = item.Id, ServiceName = item.ServiceName, ServiceDuration = item.ServiceDuration, ServicePrice = item.ServicePrice, Description = item.Description, ImageUrl=item.ImageUrl });
            }
            ViewBag.nextPage = 2;
            ViewBag.PreviousPage = 0;
            return View(servicess.AsEnumerable());
        }
        [HttpPost]
        public ActionResult Index(int pageIndex)
        {
            var services = _beautyCareService.GetPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceModel> servicess = new List<UI.Models.BeautyCareService.BeautyCareServiceModel>();
            foreach (var item in services)
            {
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel { Id = item.Id, ServiceName = item.ServiceName, ServiceDuration = item.ServiceDuration, ServicePrice = item.ServicePrice, Description = item.Description, ImageUrl = item.ImageUrl });
            }
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.PreviousPage = pageIndex == 1 ? 1 : pageIndex - 1;
            return View(servicess.AsEnumerable());
        }
        [HttpGet]
        public IActionResult BookService(int id)
        {         
                return View(new Models.BeautyCareService.BeautyCareServiceBookingModel { ServiceId = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  BookService([Bind] Models.BeautyCareService.BeautyCareServiceBookingModel booking)
        {
            if (ModelState.IsValid)
            {
                var beautyCareServicebussinessModel = new Business.Core.Model.BeautyCareService.BeautyCareServiceBookingModel
                {
                    ServiceId = booking.ServiceId,
                    UserName = booking.UserName,
                    Description = booking.Description,
                    UserEmail = booking.UserEmail,
                    UserMobileNumber = booking.UserMobileNumber,
                    Date = booking.Date,
                    From = booking.From,
                    To = booking.To
                };
                _beautyCareService.Add(beautyCareServicebussinessModel);

            }
            return RedirectToAction("Index");
        }



   
        //[HttpGet]
        //public ActionResult Create(int ServiceId)
        //{
           
        //    return View(new Models.BeautyCareService.BeautyCareServiceBookingModel { ServiceId = ServiceId });
        //}
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind] Models.BeautyCareService.BeautyCareServiceBookingModel booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var beautyCareServicebussinessModel = new Business.Core.Model.BeautyCareService.BeautyCareServiceBookingModel
        //        {
        //            OrderId = booking.OrderId,
        //            ServiceId = booking.ServiceId,
        //            UserName = booking.UserName,
        //            Description = booking.Description,
        //            UserEmail = booking.UserEmail,
        //            UserMobileNumber = booking.UserMobileNumber,
        //            Date = booking.Date,
        //            From = booking.From,
        //            To = booking.To
        //        };
        //        _beautyCareService.Add(beautyCareServicebussinessModel);
               
        //    }
        //    return RedirectToAction("Index");
        //}


    }
}
