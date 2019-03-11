using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HipicaNetCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipicaNetCore.Controllers
{
    public class MonitorController : Controller
    {
        IRepositoryHipica repo;

        public MonitorController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var listaMonitores = repo.GetMonitores();
            return View(listaMonitores);
        }

        public IActionResult ReservaPorMonitor(int idCaballo)
        {
            HttpContext.Session.SetString("CABALLO", idCaballo.ToString());
            var listaMonitores = repo.GetMonitores();
            return View(listaMonitores);
        }
    }
}