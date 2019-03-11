using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HipicaNetCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipicaNetCore.Controllers
{
    public class CaballoController : Controller
    {
        IRepositoryHipica repo;

        public CaballoController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var listaCaballos = repo.GetCaballos();
            return View(listaCaballos);
        }

        public IActionResult ReservaPorCaballo(int idNivel)
        {
            HttpContext.Session.SetString("NIVEL", idNivel.ToString());

            var listaCaballos = repo.GetCaballos().Where(x => x.Id_Nivel == idNivel).ToList();
            return View(listaCaballos);
        }
    }
}