using MasVeterinarias.Api.Responses;
using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        HttpClient client = new HttpClient();
        string url = "https://localhost:44357/api/Cliente/";
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

                cliente.UsuarioId = int.Parse(HttpContext.Session.GetString("Id"));
                Client.BaseAddress = new Uri("https://localhost:44357/api/Cliente");
                var posjob1 = Client.PostAsJsonAsync<Cliente>("cliente", cliente);
                posjob1.Wait();

                var postresult = posjob1.Result;               
                if (postresult.IsSuccessStatusCode )
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(cliente);
        }

        
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
                var _Cliente = Clientes.FirstOrDefault(e => e.Id.Equals(id));
                return View(_Cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> UpdateAsync(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
                var _Cliente = Clientes.FirstOrDefault(e => e.Id.Equals(id));
                return View(_Cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Cliente ClienteDto)
        {
            client.BaseAddress = new Uri("https://localhost:44357/api/Cliente/");
           
            var putTask = await client.PutAsJsonAsync("?id=" + ClienteDto.Id, ClienteDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(ClienteDto);
        }
    }
}
