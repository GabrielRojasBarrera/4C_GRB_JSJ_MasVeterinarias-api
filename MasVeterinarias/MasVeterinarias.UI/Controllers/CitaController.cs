using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class CitaController : Controller
    {
        public string url = "https://localhost:44357/api/Cita";
        public IActionResult Index()
        {
            //IEnumerable<Cita> cita = null;
            //using (var Client = new HttpClient())
            //{
            //    Client.BaseAddress = new Uri("https://localhost:44357/api/");
            //    var responseTask = Client.GetAsync("Cita");

            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readjob = result.Content.ReadAsAsync<IList<Cita>>();
            //        readjob.Wait();
            //        cita = readjob.Result;


            //    }


            //}
            return View(/*cita*/);
        }


        public async Task<JsonResult> GetEvents()
        {
            var Client = new HttpClient();
            var json = await Client.GetStringAsync(url);
            var Citas = JsonConvert.DeserializeObject<List<Cita>>(json);

            var events = Citas.ConvertAll(e => new
            {
                id = e.Id,
                start = e.Fecha,
                petname = e.NombreMascota,
                clientid = e.ClienteId,
                title = e.ServicioId,
                hours = e.Hora,
                status = e.Estatus
            }).ToArray();
            return new JsonResult(events);
        }


        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            using (var Client = new HttpClient())
            {
                cita.Estatus = "Pendiente";
                cita.VeterinariaId = 1;
                cita.ClienteId = int.Parse(HttpContext.Session.GetString("Id")); 
                Client.BaseAddress = new Uri("https://localhost:44357/api/Cita");
                var posjob = Client.PostAsJsonAsync<Cita>("Cita", cita);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Details", "Cliente");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(cita);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Cita cita = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Cita/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Cita>();
                    readtask.Wait();
                    cita = readtask.Result;
                }
            }

            return View(cita);
        }


        [HttpPost]
        public ActionResult Edit(Cita cita)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/Cita");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + cita.Id, cita);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(cita);
        }

        public ActionResult Details(int id)
        {
            Cita cita = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Cita/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Cita>();
                    readtask.Wait();
                    cita = readtask.Result;
                }
            }

            return View(cita);
        }
        public ActionResult Detalles()
        {
            IEnumerable<Cita> cita = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("Cita");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Cita>>();
                    readjob.Wait();
                    cita = readjob.Result;
                }


            }
            return View(cita);


        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Cita/" + id.ToString());


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
