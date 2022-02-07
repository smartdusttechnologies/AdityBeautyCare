using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel { Id = item.Id, Name = item.Name, Duration = item.Duration, Price = item.Price, Description = item.Description, ImageUrl=item.ImageUrl });
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
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel { Id = item.Id, Name = item.Name, Duration = item.Duration, Price = item.Price, Description = item.Description, ImageUrl = item.ImageUrl });
            }
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.PreviousPage = pageIndex == 1 ? 1 : pageIndex - 1;
            return View(servicess.AsEnumerable());
        }
        [HttpGet]
        public IActionResult BookService(int id)
        {         
           var beautyCareServiceBookingModel = new Models.BeautyCareService.BeautyCareServiceBookingModel { Date = DateTime.Now.ToString("yyyy-MM-dd"), ServiceId = id };
                return View(beautyCareServiceBookingModel);
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

        public IActionResult adminDashboard()
        {
            var orders = _beautyCareService.GetbookingPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel> orderss = new List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel>();
            foreach (var item in orders)
            {
                orderss.Add(new Models.BeautyCareService.BeautyCareServiceBookingModel { Id = item.Id, UserName = item. UserName, UserEmail=item.UserEmail,Date=item.Date,Description=item.Description,UserMobileNumber=item.UserMobileNumber,From=item.From,To=item.To});
            }
            ViewBag.nextPage = 2;
            ViewBag.PreviousPage = 0;
            return View(orderss.AsEnumerable());
        }
        [HttpPost]
        public ActionResult adminDashboard(int pageIndex)
        {
            var orders = _beautyCareService.GetbookingPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel> orderss = new List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel>();
            foreach (var item in orders)
            {
                orderss.Add(new Models.BeautyCareService.BeautyCareServiceBookingModel { Id = item.Id, UserName = item.UserName, UserEmail = item.UserEmail, Date = item.Date, Description = item.Description, UserMobileNumber = item.UserMobileNumber, From = item.From, To = item.To });
            }
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.PreviousPage = pageIndex == 1 ? 1 : pageIndex - 1;
            return View(orderss.AsEnumerable());
        }

        [HttpGet]
        public ActionResult adminEditService(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orders = _beautyCareService.Getbooking((int)id);
            if (orders == null)
            {
                return NotFound();
            }
            var beautyCareServiceUIModel = new Models.BeautyCareService.BeautyCareServiceBookingModel
            {
                Id = orders.Id,
                UserName = orders.UserName,
                UserEmail = orders.UserEmail,
                Date = orders.Date,
                Description = orders.Description,
                UserMobileNumber = orders.UserMobileNumber,
                From = orders.From,
                To = orders.To,
                ServiceId=orders.ServiceId,
            };
            return View(beautyCareServiceUIModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult adminEditService(int id, [Bind] Models.BeautyCareService.BeautyCareServiceBookingModel beautyCareService)
        {
            if (id != beautyCareService.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var beautyCareServiceBusinessModel = new Business.Core.Model.BeautyCareService.BeautyCareServiceBookingModel
                {
                    Id = beautyCareService.Id,
                    ServiceId = beautyCareService.ServiceId,
                    UserName = beautyCareService.UserName,
                     Date = beautyCareService.Date,
                      Description= beautyCareService.Description,
                      From = beautyCareService.From,
                      To = beautyCareService.To,
                      UserEmail=beautyCareService.UserEmail,
                      UserMobileNumber=beautyCareService.UserMobileNumber
                      
                };
                _beautyCareService.Updatebooking(id, beautyCareServiceBusinessModel);
                return View(beautyCareService);
            }
            return RedirectToAction("adminDashboard");
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
