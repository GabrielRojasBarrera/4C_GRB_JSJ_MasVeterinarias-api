using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace MasVeterinarias.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }
       
        public string url = "https://localhost:44357/api/Usuario";

        public ActionResult Index()
        {
            IEnumerable<Usuario> usuario = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("usuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Usuario>>();
                    readjob.Wait();
                    usuario = readjob.Result;
                }


            }
            return View(usuario);
        }

        //POST: Usuario
        public ActionResult Create()
        {
                        
           return View();
                       
        }
        [HttpPost]
        public async Task<IActionResult> Create(Login login, Usuario usuario)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/Usuario");
                var posjob = Client.PostAsJsonAsync<Usuario>("usuario", usuario);
                posjob.Wait();
                var json = await Client.GetStringAsync(url);
                var Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                var _Usuario = Usuarios.FirstOrDefault(e => e.Email.Equals(login.Email) && e.Password.Equals(login.Password));
                HttpContext.Session.SetString("Id", _Usuario.Id.ToString());
                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)

                    return RedirectToAction("Create", "Cliente");
                
            }
           
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(usuario);
        }

        public ActionResult CreateV()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateV(Login login, Usuario usuario)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/Usuario");
                var posjob = Client.PostAsJsonAsync<Usuario>("usuario", usuario);
                posjob.Wait();
                var json = await Client.GetStringAsync(url);
                var Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                var _Usuario = Usuarios.FirstOrDefault(e => e.Email.Equals(login.Email) && e.Password.Equals(login.Password));
                HttpContext.Session.SetString("Id", _Usuario.Id.ToString());
                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Create", "Veterinaria");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(usuario);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Usuario usuario = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("usuario/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Usuario>();
                    readtask.Wait();
                    usuario = readtask.Result;
                }
            }

            return View(usuario);
        }
       

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/Usuario");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + usuario.Id, usuario);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(usuario);
        }

        public ActionResult Details(int id)
        {
            Usuario usuario = null;
            using (var client = new HttpClient())
            {
                id = int.Parse(HttpContext.Session.GetString("Id"));
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("usuario/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Usuario>();
                    readtask.Wait();
                    usuario = readtask.Result;
                }
            }

            return View(usuario);
        }

        
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("usuario/" + id.ToString());
                

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

    }
}
