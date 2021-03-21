using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class ServicioController : Controller
    {
        private IWebHostEnvironment _enviroment;

        public ServicioController(IWebHostEnvironment env)
        {
            _enviroment = env;
        }
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
        public async Task<ActionResult> Create(Servicio servicio)
        {
            var filename = System.IO.Path.Combine(_enviroment.ContentRootPath,
               "wwwroot", "Uploads", "Services", servicio.ImageService.FileName);

            await servicio.ImageService.CopyToAsync(
               new System.IO.FileStream(filename, System.IO.FileMode.Create));
            using (var Client = new HttpClient())
            {
                servicio.Imagen = servicio.ImageService.FileName;
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

        public ActionResult Detalles()
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
