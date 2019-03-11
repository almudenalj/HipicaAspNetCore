using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HipicaNetCore.Models;
using HipicaNetCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipicaNetCore.Controllers
{
    public class ReservaController : Controller
    {
        IRepositoryHipica repo;

        public ReservaController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var usuarioLogueado = HttpContext.User;
            if (usuarioLogueado.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Validacion");
            }
            var listaReservas = new List<Reserva>();
            var idRol = usuarioLogueado.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault();
            var idUsuario = usuarioLogueado.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            if (idRol != null && idRol.Value == "ADMINISTRADOR")
            {
                listaReservas = repo.GetReservas();
            }
            else if (idRol != null && idRol.Value == "USUARIO" && idUsuario != null)
            {
                int idUsuarioInt = Convert.ToInt32(idUsuario.Value);
                listaReservas = repo.GetReservas().Where(x => x.IdUsuario == idUsuarioInt).ToList();
            }
            return View(listaReservas);
        }

        public IActionResult ReservaFinal(int IdRuta)
        {
            HttpContext.Session.SetString("RUTA", IdRuta.ToString());
            return View();
        }

        [HttpPost]
        public IActionResult ReservaFinal(Reserva reserva)
        {
            try
            {
                var usuarioLogueado = HttpContext.User;

                var idNivel = HttpContext.Session.GetString("NIVEL");
                var idCaballo = HttpContext.Session.GetString("CABALLO");
                var idMonitor = HttpContext.Session.GetString("MONITOR");
                var idRuta = HttpContext.Session.GetString("RUTA");
                var idUsuario = usuarioLogueado.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                if (idNivel is null || idCaballo is null || idMonitor is null || idRuta is null || idUsuario is null)
                {
                    ViewBag.Mensaje = "Error. Antes de reservar se tiene que seleccionar un nivel, un caballo, un monitor y una ruta.";
                    return View();
                }

                reserva.IdNivel = Convert.ToInt32(idNivel);
                reserva.IdCaballo = Convert.ToInt32(idCaballo);
                reserva.IdMonitor = Convert.ToInt32(idMonitor);
                reserva.IdRuta = Convert.ToInt32(idRuta);
                reserva.IdUsuario = Convert.ToInt32(idUsuario.Value);

                repo.RegistrarReserva(reserva);
                ViewBag.Mensaje = "La reserva se ha realizado correctamente";

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Se ha producido un error al reservar";
            }
            return View();
        }
    }


}
