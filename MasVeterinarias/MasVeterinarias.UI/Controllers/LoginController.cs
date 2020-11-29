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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(Login login)
        {
            var json = await client.GetStringAsync(url);
            var Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            var _Usuario = Usuarios.FirstOrDefault(e => e.Email.Equals(login.Email) && e.Password.Equals(login.Password));
            if (_Usuario != null )
            {
                HttpContext.Session.SetString("Id", _Usuario.Id.ToString());
                return RedirectToAction("UserIndex", "Home");
            }
           
            else if (_Usuario == null)
            {

                login.status = false;
                return View();
            }
            return View();
        }
        public IActionResult Cita()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Id");
            return RedirectToAction("Index", "Home");
        }

    }
}
