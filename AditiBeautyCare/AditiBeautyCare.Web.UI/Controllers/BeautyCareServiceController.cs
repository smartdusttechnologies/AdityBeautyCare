using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Configuration;

namespace AditiBeautyCare.Web.UI.Controllers
{
    /// <summary>
    /// Implimenting BeautyCareServiceController
    /// </summary>
    public class BeautyCareServiceController : Controller
    {
        private readonly ILogger<BeautyCareServiceController> _logger;
        private readonly IBeautyCareService _beautyCareService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Declaring the variables for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="beautyCareService"></param>
        /// <param name="hostingEnvironment"></param>
        public BeautyCareServiceController(ILogger<BeautyCareServiceController> logger, IBeautyCareService beautyCareService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _logger = logger;
            _beautyCareService = beautyCareService;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        /// <summary>
        /// For getting page list and data 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var services = _beautyCareService.GetPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceModel> servicess = new List<UI.Models.BeautyCareService.BeautyCareServiceModel>();
            foreach (var item in services)
            {
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel { Id = item.Id, Name = item.Name, Duration = item.Duration, Price = item.Price, Description = item.Description, FilePath=item.FilePath });
            }
            ViewBag.nextPage = 2;
            ViewBag.PreviousPage = 0;
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;

            return View(servicess.AsEnumerable());
        }

        /// <summary>
        /// For getting data with page index
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int pageIndex)
        {
            var services = _beautyCareService.GetPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceModel> servicess = new List<UI.Models.BeautyCareService.BeautyCareServiceModel>();
            foreach (var item in services)
            {
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel { Id = item.Id, Name = item.Name, Duration = item.Duration, Price = item.Price, Description = item.Description, ImageUrl=item.ImageUrl });
            }
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.PreviousPage = pageIndex == 1 ? 1 : pageIndex - 1;
            return View(servicess.AsEnumerable());
        }

        /// <summary>
        /// For adding service  it will load the view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult adminAddService(int id)
        {
            var beautyCareServiceModel = new Models.BeautyCareService.BeautyCareServiceModel { Id = id };
            return View(beautyCareServiceModel);
        }

        /// <summary>
        /// For adding  service  it will add to data to database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult adminAddService([Bind] Models.BeautyCareService.BeautyCareServiceModel addservice)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = _configuration["ImageString:Prefix"] + _configuration["ImageString:ImageStore"] + _configuration["ImageString:Postfix"];
                string uniqueFileName = UploadedFile(addservice);
                var beautyCareServicebussinessModel = new Business.Core.Model.BeautyCareService.BeautyCareServiceModel
                               {
                    Name = addservice.Name,
                    Description = addservice.Description,
                    Duration = addservice.Duration,
                    FilePath = uploadsFolder + uniqueFileName,
                    Price = addservice.Price
                };
                _beautyCareService.Add(beautyCareServicebussinessModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        private string UploadedFile(Models.BeautyCareService.BeautyCareServiceModel addservice)
        {
                       
            string uniqueFileName = null;
          // if (File.Length > 0 && File.Length < (1000000 / 5)) //Image Greater than 0 and equal up To 100Kb
            {
                if (addservice.ImageUrl != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["ImageString:ImageStore"]);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + addservice.ImageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))

                        //if (addservice.ImageUrl.Length > 0 && addservice.ImageUrl.Length < (100000)) //Image Greater than 0 and equal up To 100Kb
                        {
                            addservice.ImageUrl.CopyTo(fileStream);
                        }                   
                }
            }

            return uniqueFileName;
        }

        /// <summary>
        /// For Booking service  it will load the view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BookService(int id, string serviceName)
        {
            var beautyCareServiceBookingModel = new Models.BeautyCareService.BeautyCareServiceBookingModel { Date = DateTime.Now.Date, ServiceId = id, ServiceName = serviceName };
            return View(beautyCareServiceBookingModel);
        }

        /// <summary>
        /// For Booking service  it will add data to database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookService([Bind] Models.BeautyCareService.BeautyCareServiceBookingModel booking)
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
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");

            }
            return View(booking);
        }

        /// <summary>
        /// For admin dashboard  it will load the view 
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public IActionResult adminDashboard()
        {
            var orders = _beautyCareService.GetbookingPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel> orderss = new List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel>();
            foreach (var item in orders)
            {
                orderss.Add(new Models.BeautyCareService.BeautyCareServiceBookingModel { Id = item.Id, UserName = item.UserName, UserEmail = item.UserEmail, Date = item.Date, Description = item.Description, UserMobileNumber = item.UserMobileNumber, From = item.From, To = item.To, ServiceName = item.ServiceName });
            }
            ViewBag.nextPage = 2;
            ViewBag.PreviousPage = 0;
            return View(orderss.AsEnumerable());
        }

        /// <summary>
        /// for admindashboard it loads the data
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult adminDashboard(int pageIndex)
        {
            var orders = _beautyCareService.GetbookingPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel> orderss = new List<UI.Models.BeautyCareService.BeautyCareServiceBookingModel>();
            foreach (var item in orders)
            {
                orderss.Add(new Models.BeautyCareService.BeautyCareServiceBookingModel { Id = item.Id, UserName = item.UserName, UserEmail = item.UserEmail, Date = item.Date, Description = item.Description, UserMobileNumber = item.UserMobileNumber, From = item.From, To = item.To, ServiceName = item.ServiceName });
            }
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.PreviousPage = pageIndex == 1 ? 1 : pageIndex - 1;
            return View(orderss.AsEnumerable());
        }

        /// <summary>
        /// Admin can edit the bookings this will load the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                ServiceId = orders.ServiceId,
            };
            return View(beautyCareServiceUIModel);
        }

        /// <summary>
        /// admin can edit any user bookingdata
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
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
                    Description = beautyCareService.Description,
                    From = beautyCareService.From,
                    To = beautyCareService.To,
                    UserEmail = beautyCareService.UserEmail,
                    UserMobileNumber = beautyCareService.UserMobileNumber

                };
                _beautyCareService.Updatebooking(id, beautyCareServiceBusinessModel);
                return View(beautyCareService);
            }
            return RedirectToAction("adminDashboard");
        }

        /// <summary>
        /// To Delete the Service Booked by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int? id)
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
                ServiceId = orders.ServiceId,
                ServiceName = orders.ServiceName
            };
            return View(beautyCareServiceUIModel);
        }

        [HttpGet]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _beautyCareService.Delete((int)id);
            return RedirectToAction("adminDashboard");
        }
    }

}