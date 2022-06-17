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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using static Google.Apis.Drive.v3.DriveService;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections;
using ServiceStack;

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
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private Google.Apis.Drive.v3.Data.File newFile;
        private object listRequest;
        private string ApplicationName;

        public object ResponseBody { get; private set; }

        public DriveService GetService()
        {

            //get Credentials from client_secret.json file 
            UserCredential credential;

            //Root Folder of project
            var CSPath = _hostingEnvironment.WebRootPath;
            using (var stream = new FileStream(Path.Combine(CSPath, "client_secret_189169897000-ploiurum7nj6gtnn9tols71pdps79iu2.apps.googleusercontent.com (1).json"), FileMode.Open, FileAccess.Read))
            {
                String FolderPath = _hostingEnvironment.WebRootPath;
                String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user",
                CancellationToken.None,
                new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveMVCUpload",
            });
            return service;
        }

        public string CreateFolder(string parent, string folderName)
        {
            var service = GetService();
            // File metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "ApplicationImageUpload",
                MimeType = "application/vnd.google-apps.folder"
            };
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 100;
            listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            bool isFolderExist = false;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    newFile = new Google.Apis.Drive.v3.Data.File();
                    newFile.Name = fileMetadata.Name;
                    if (file.Name == newFile.Name)
                    {
                        isFolderExist = true;
                        Console.WriteLine("File already existing... Skip creation");
                        return file.Id;
                    }
                }
            }

             if(!isFolderExist)
             {
                var request = service.Files.Create(fileMetadata);
                request.Fields = "id";
                //var uniqueFileName = Guid.NewGuid().ToString();
                var file = request.Execute();
                //var result = uniqueFileName + service.Files.Create(newFile).Execute();
                //Console.WriteLine("Folder ID: " + uniqueFileName + file.Id);
                return file.Id;
             }
            return (string)ResponseBody;
        }

        public string UploadFile(IFormFile file, string fileName, string fileMime, string folder, string fileDescription)
        {
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            var uniqueFileName = Guid.NewGuid().ToString();
            driveFile.Name = uniqueFileName + fileName;

            driveFile.Description = fileDescription;
            //driveFile.MimeType = fileMime;
            driveFile.Parents = new string[] { folder };
            
            using ( var abc = file.OpenReadStream())
            {
                    var request = service.Files.Create(driveFile, abc, fileMime);
                    request.Fields = "id";

                    var response = request.Upload();
                    if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                    {
                        throw response.Exception;
                    }
                    var imageVal = request.ResponseBody.Id;
                    //return request.ResponseBody.Id;
                    return imageVal;
            }
        }

        public IEnumerable<Google.Apis.Drive.v3.Data.File> GetFiles(string folder)
        {
            var service = GetService();

            var fileList = service.Files.List();
            fileList.Q = $"mimeType!='application/vnd.google-apps.folder' and '{folder}' in parents";
            fileList.Fields = "nextPageToken, files(id, name, size, mimeType)";

            var result = new List<Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            do
            {
                fileList.PageToken = pageToken;
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                pageToken = filesResult.NextPageToken;
                result.AddRange(files);
            }
            while (pageToken != null);
            return result;
        }

        /// <summary>
        /// For getting page list and data 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //var abcd = UploadFile();
            var services = _beautyCareService.GetPages(1);
            List<UI.Models.BeautyCareService.BeautyCareServiceModel> servicess = new List<UI.Models.BeautyCareService.BeautyCareServiceModel>();
            
            foreach (var item in services)
            {
                    servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel 
                    { 
                        Id = item.Id, 
                        Name = item.Name, 
                        Duration = item.Duration, 
                        Price = item.Price,
                        Description = item.Description,
                        FilePath = item.FilePath
                    });
            }
                ViewBag.nextPage = 2;
                ViewBag.PreviousPage = 0;
                ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
                return View(servicess.AsEnumerable());
               // return null;
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
                servicess.Add(new Models.BeautyCareService.BeautyCareServiceModel 
                { 
                    Id = item.Id, 
                    Name = item.Name, 
                    Duration = item.Duration, 
                    Price = item.Price, 
                    Description = item.Description, 
                    ImageUrl = item.ImageUrl 
                });
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
                string uploadsFolder = CreateFolder("Test", "new");
                var xyz = new FileExtensionContentTypeProvider();
                xyz.TryGetContentType(addservice.FilePath, out string contenttype);
                string uniqueFileName = UploadFile(addservice.ImageUrl, Path.GetFileName(addservice.FilePath), contenttype, uploadsFolder, "");
               // var imgVal = UploadFile(asdf);
                var beautyCareServicebussinessModel = new Business.Core.Model.BeautyCareService.BeautyCareServiceModel
                {
                    Name = addservice.Name,
                    Description = addservice.Description,
                    Duration = addservice.Duration,
                    FilePath = uniqueFileName,
                    Price = addservice.Price
                };
                _beautyCareService.Add(beautyCareServicebussinessModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        //private string UploadedFile(Models.BeautyCareService.BeautyCareServiceModel addservice)
        //{
        //    string uniqueFileName = null;
        //    {
        //        if (addservice.ImageUrl != null)
        //        {
        //            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["ImageString:ImageStore"]);
        //            uniqueFileName = Guid.NewGuid().ToString() + "_" + addservice.ImageUrl.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                addservice.ImageUrl.CopyTo(fileStream);
        //            }
        //        }
        //    }
        //    return uniqueFileName;
        //}


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
        /// <summary>
        /// Delete the booking by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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