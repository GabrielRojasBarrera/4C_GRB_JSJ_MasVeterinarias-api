using MasVeterinarias.Api.Responses;
using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            IEnumerable<Cliente> clientes = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("cliente");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Cliente>>();
                    readjob.Wait();
                    clientes = readjob.Result;
                }


            }
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Cliente cliente)
        {
            using (var Client = new HttpClient())
            {
                cliente.Id = int.Parse(HttpContext.Session.GetString("Id"));
                cliente.UsuarioId = int.Parse(HttpContext.Session.GetString("Id"));
                Client.BaseAddress = new Uri("https://localhost:44357/api/Cliente");
                var posjob1 = Client.PostAsJsonAsync<Cliente>("cliente", cliente);
                posjob1.Wait();

                var postresult = posjob1.Result;               
                if (postresult.IsSuccessStatusCode )
                    return RedirectToAction("UserIndex", "Home");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(cliente);
        }



        public IActionResult Details(int id)
        {
            
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                id = int.Parse(HttpContext.Session.GetString("Id")); 
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Cliente/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Cliente>();
                    readtask.Wait();
                    cliente = readtask.Result;
                }
            }
            return View(cliente);        
        }


        public  IActionResult Edit(int id)
        {
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                id = int.Parse(HttpContext.Session.GetString("Id")); 
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Cliente/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Cliente>();
                    readtask.Wait();
                    cliente = readtask.Result;
                }
            }

            return View(cliente);

        }


        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://localhost:44357/api/Servicio");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + cliente.Id, cliente);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Servicio/" + id.ToString());


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
