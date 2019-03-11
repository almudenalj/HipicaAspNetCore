using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HipicaNetCore.Models;
using HipicaNetCore.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipicaNetCore.Controllers
{
    public class ValidacionController : Controller
    {
        IRepositoryHipica repo;

        public ValidacionController(IRepositoryHipica repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            usuario.Rol = "USUARIO";
            repo.RegistrarUsuario(usuario);
            return View();
        }

        //GET: Login
        public IActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        public async Task<IActionResult>
            Login(string email, string password)
        {
            Usuario usuarioBBDD = repo.GetUsuario(email, password);
            if (usuarioBBDD is null)
            {
                ViewBag.Mensaje = "Usuario/Password incorrecto";
                return View();
            }
            else
            {
                //CREAMOS NUESTRA IDENTIDAD CLAIMS
                ClaimsIdentity identidad =
                    new ClaimsIdentity(
                CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identidad.AddClaim(new Claim(ClaimTypes.Name, usuarioBBDD.Nombre));
                identidad.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuarioBBDD.Id.ToString()));
                identidad.AddClaim(new Claim(ClaimTypes.Role, usuarioBBDD.Rol));
                ClaimsPrincipal principal = new ClaimsPrincipal(identidad);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                    , principal, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddMinutes(2)
                    });

                var reserva = HttpContext.Session.GetString("RESERVA");
                if (reserva is null || reserva == "")
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    HttpContext.Session.SetString("RESERVA", "");
                    return RedirectToAction("ReservaPorNivel", "Nivel");
                }
            }
        }
    }
}