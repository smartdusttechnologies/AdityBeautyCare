﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AditiBeautyCare.Business.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using AditiBeautyCare.Web.UI.Models;

namespace AditiBeautyCare.Web.UI.Controllers
{
    public class SampleController : Controller
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ISampleService _sampleService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SampleController(ILogger<SampleController> logger, ISampleService sampleService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _sampleService = sampleService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var samples = _sampleService.GetPages(1);
            List<UI.Models.Sample.SampleModel> sampless = new List<UI.Models.Sample.SampleModel>();

            foreach (var item in samples)
            {
                sampless.Add(new Models.Sample.SampleModel { Id = item.Id, Name = item.Name, Description = item.Description });
            }
            ViewBag.nextPage = 2;
            ViewBag.PreviousPage = 0;
            return View(sampless.AsEnumerable());
        }

        [HttpPost]
        public ActionResult Index(int pageIndex)
        {
            var samples = _sampleService.GetPages(pageIndex);
            List<UI.Models.Sample.SampleModel> sampless = new List<UI.Models.Sample.SampleModel>();

            foreach (var item in samples)
            {
                sampless.Add(new Models.Sample.SampleModel { Id = item.Id, Name = item.Name, Description = item.Description });
            }
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.PreviousPage = pageIndex == 1 ? 1 : pageIndex - 1;
            return View(sampless.AsEnumerable());
        }

        /// <summary>
        /// Shows Details for Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sample = _sampleService.Get((int)id);


            if (sample == null)
            {
                return NotFound();
            }

            var sampleUIModel = new Models.Sample.SampleModel
            {

                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description,
            };
            return View(sampleUIModel);

        }

        // GET: SampleController/Create
        [HttpGet]
        public ActionResult Create(int id)
        {

            return base.View(new Models.Sample.SampleModel { Id = id });
        }

        // POST: SampleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Models.Sample.SampleModel sample)
        {
            if (ModelState.IsValid)
            {
                var samplebussinessModel = new AditiBeautyCare.Business.Core.Model.SampleModel
                {
                    Id = sample.Id,
                    Name = sample.Name,
                    Description = sample.Description
                };
                _sampleService.Add(samplebussinessModel);
                return RedirectToAction("Index");
            }
            return View(sample);
        }

        // GET: SampleController/Edit/
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sample = _sampleService.Get((int)id);


            if (sample == null)
            {
                return NotFound();
            }

            var sampleUIModel = new Models.Sample.SampleModel
            {

                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description,
            };
            return View(sampleUIModel);
        }

        // POST: SampleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] Models.Sample.SampleModel sample)
        {
            if (id != sample.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                var sampleBusinessModel = new Business.Core.Model.SampleModel
                {
                    Id = sample.Id,
                    Name = sample.Name,
                    Description = sample.Description
                };
                _sampleService.Update(id, sampleBusinessModel);

                return RedirectToAction("Index");
            }

            return View(sample);

        }

        // GET: SampleController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var sample = _sampleService.Get((int)id);


            if (sample == null)
            {
                return NotFound();
            }

            var sampleUIModel = new Models.Sample.SampleModel
            {

                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description,
            };
            return View(sampleUIModel);
        }

        // POST: SampleController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _sampleService.Delete((int)id);
            return RedirectToAction("Index");

        }
    }
}