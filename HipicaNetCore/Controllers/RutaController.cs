using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HipicaNetCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipicaNetCore.Controllers
{
    public class RutaController : Controller
    {
        IRepositoryHipica repo;

        public RutaController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var listaRutas = repo.GetRutas();
            return View(listaRutas);
        }

        public IActionResult ReservaPorRuta(int idMonitor)
        {
            HttpContext.Session.SetString("MONITOR", idMonitor.ToString());
            var idNivel = HttpContext.Session.GetString("NIVEL");
            var idNivelNumerico = Convert.ToInt32(idNivel);
            var listaRutas = repo.GetRutas().Where(x => x.Id_Nivel == idNivelNumerico).ToList();
            return View(listaRutas);
        }
    }
}