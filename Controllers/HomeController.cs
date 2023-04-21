using Final_dlbaldwi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final_dlbaldwi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEntertainmentRepository _repo;

        public HomeController(ILogger<HomeController> logger, IEntertainmentRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entertainers()
        {
            var entertainers = _repo.Entertainers.ToList();
            return View(entertainers);
        }

        [HttpGet]
        public IActionResult About(int entertainerid)
        {
            var entertainer = _repo.Entertainers.Single(e => e.EntertainerId == entertainerid);

            return View(entertainer);
        }

        [HttpPost]
        public IActionResult About(Entertainers entertainer)
        {
            _repo.UpdateEntertainers(entertainer);
            var ent = _repo.Entertainers.Single(e => e.EntertainerId == entertainer.EntertainerId);
            return View("Entertainers");
        }

        [HttpGet]
        public IActionResult Add()
        {
            Entertainers entertainer = new Entertainers();

            long nextId = _repo.GetNextId();

            ViewBag.NextId = nextId;

            return View(entertainer);
        }

        [HttpPost]
        public IActionResult Add(Entertainers entertainer)
        {
            _repo.AddEntertainer(entertainer);
            return View("Entertainers");
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            Entertainers entertainer = _repo.Entertainers.Single(e => e.EntertainerId == id);
            _repo.DeleteEntertainer(entertainer);
            return View("Entertainers");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
