using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HipicaNetCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipicaNetCore.Controllers
{
    public class NivelController : Controller
    {
        IRepositoryHipica repo;

        public NivelController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var listaNiveles = repo.GetNiveles();
            return View(listaNiveles);
        }

        public IActionResult ReservaPorNivel()
        {
            var usuarioLogueado = HttpContext.User;
            if (usuarioLogueado.Identity.IsAuthenticated == false)
            {
                HttpContext.Session.SetString("RESERVA", "SI");
                return RedirectToAction("Login", "Validacion");
            }
            var listaNiveles = repo.GetNiveles();
            return View(listaNiveles);
        }
    }
}