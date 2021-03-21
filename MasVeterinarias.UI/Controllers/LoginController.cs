using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        HttpClient client = new HttpClient();
        public string url = "https://localhost:44357/api/Usuario";
        public string urlv = "https://localhost:44357/api/Veterinaria";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login login, Veterinaria veterinaria, Usuario usuario)
        {
            var json = await client.GetStringAsync(url);
            var jsonV = await client.GetStringAsync(urlv);
            var Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            var Veterinarias = JsonConvert.DeserializeObject<List<Veterinaria>>(jsonV);
            var _Usuario = Usuarios.FirstOrDefault(e => e.Email.Equals(login.Email) && e.Password.Equals(login.Password) );
            var _Usuariov = Veterinarias.FirstOrDefault(e => e.UsuarioId.Equals(_Usuario.Id));
            if (_Usuario != null && _Usuariov == null)
            {
                HttpContext.Session.SetString("Id", _Usuario.Id.ToString());
                return RedirectToAction("Usuario");
            }
            else if (_Usuario != null && _Usuariov!= null)
            {
                HttpContext.Session.SetString("Id", _Usuariov.Id.ToString());
                return RedirectToAction("Veterinaria");
            }
            else if (_Usuario == null && _Usuariov == null)
            {

                login.status = false;
                return View();
            }
            return View();

        }
        public IActionResult Usuario()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return RedirectToAction("UserIndex", "Home");
                
            }
            else
            {
                return View();
            }
        }

        public IActionResult Veterinaria()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return RedirectToAction("VIndex", "Home");

            }
            else
            {
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Id");
            return RedirectToAction("Index", "Home");
        }

    }
}
