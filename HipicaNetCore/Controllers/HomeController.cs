using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HipicaNetCore.Models;
using HipicaNetCore.Repositories;

namespace HipicaNetCore.Controllers
{
    public class HomeController : Controller
    {

        IRepositoryHipica repo;

        public HomeController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var prueba = repo.GetCaballos();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
