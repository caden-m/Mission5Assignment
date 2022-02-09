using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext daContext { get; set; }

        public HomeController(ILogger<HomeController> logger, ApplicationContext someName)
        {
            _logger = logger;
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Application()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]

        public IActionResult Application(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View(ar);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Collection()
        {
            var movies = daContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.responses.Single(x => x.ApplicationId == applicationid);

            return View("Application", application);
        }

        [HttpPost]

        public IActionResult Edit (ApplicationResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();
            return RedirectToAction("Collection");
        
        }


        [HttpGet]

        public IActionResult Delete(int applicationid)
        {

            var application = daContext.responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("Collection");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
