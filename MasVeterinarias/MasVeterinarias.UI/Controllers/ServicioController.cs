using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class ServicioController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Servicio> Servicio = null;
            using (var Client = new HttpClient())
            {
                
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("Servicio");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Servicio>>();
                    readjob.Wait();
                    Servicio = readjob.Result;
                }


            }
            return View(Servicio);
        }

        //POST: Servicio
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(Servicio servicio)
        {
            using (var Client = new HttpClient())
            {
                servicio.VeterinariaId = 1;
                Client.BaseAddress = new Uri("https://localhost:44357/api/Servicio");
                var posjob = Client.PostAsJsonAsync<Servicio>("servicio", servicio);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(servicio);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Servicio Servicio = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Servicio/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Servicio>();
                    readtask.Wait();
                    Servicio = readtask.Result;
                }
            }

            return View(Servicio);
        }


        [HttpPost]
        public ActionResult Edit(Servicio Servicio)
        {
            using (var client = new HttpClient())
            {
                Servicio.VeterinariaId = 1;
                client.BaseAddress = new Uri("https://localhost:44357/api/Servicio");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + Servicio.Id, Servicio);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Servicio);
        }

        public ActionResult Detalles(int id)
        {
            Servicio Servicio = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Servicio/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Servicio>();
                    readtask.Wait();
                    Servicio = readtask.Result;
                }
            }

            return View(Servicio);
        }
        public ActionResult Details(int id)
        {
            Servicio Servicio = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Servicio/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Servicio>();
                    readtask.Wait();
                    Servicio = readtask.Result;
                }
            }

            return View(Servicio);
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
