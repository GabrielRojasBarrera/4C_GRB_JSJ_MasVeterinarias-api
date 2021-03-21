using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{

    public class VeterinariaController : Controller
    {
        private IWebHostEnvironment _enviroment;

        public VeterinariaController(IWebHostEnvironment env)
        {
            _enviroment = env;
        }

        public ActionResult Index()
        {
            IEnumerable<Veterinaria> veterinaria = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("veterinaria");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Veterinaria>>();
                    readjob.Wait();
                    veterinaria = readjob.Result;
                }


            }
            return View(veterinaria);
        }

        //POST: Usuario
        public IActionResult Create()
        {
            
                return View();
            
        }

        [HttpPost]
        public async Task<ActionResult> Create(Veterinaria veterinaria)
        {
            //FileStream fs;
            var filename = System.IO.Path.Combine(_enviroment.ContentRootPath,
                "wwwroot", "Uploads", "Banners", veterinaria.MyFile.FileName);

            await  veterinaria.MyFile.CopyToAsync(
             /*fs =*/ new System.IO.FileStream(filename, System.IO.FileMode.Create));
            //fs.Close();
            using (var Client = new HttpClient())
            {
               veterinaria.Id = int.Parse(HttpContext.Session.GetString("Id"));
                veterinaria.Imagen = veterinaria.MyFile.FileName;
                veterinaria.UsuarioId = int.Parse(HttpContext.Session.GetString("Id"));
                Client.BaseAddress = new Uri("https://localhost:44357/api/Veterinaria");
                var posjob = Client.PostAsJsonAsync<Veterinaria>("veterinaria", veterinaria);
                posjob.Wait();
               
                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("VIndex", "Home");
            }
            
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(veterinaria);
        }
        
       

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Veterinaria veterinaria = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("veterinaria/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Veterinaria>();
                    readtask.Wait();
                    veterinaria = readtask.Result;
                }
            }

            return View(veterinaria);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(Veterinaria veterinaria)
        {
            var filename = System.IO.Path.Combine(_enviroment.ContentRootPath,
               "wwwroot", "Uploads", veterinaria.MyFile.FileName);

            await veterinaria.MyFile.CopyToAsync(
               new System.IO.FileStream(filename, System.IO.FileMode.Create));
            using (var client = new HttpClient())
            {
                veterinaria.UsuarioId = int.Parse(HttpContext.Session.GetString("Id"));
                veterinaria.Imagen = veterinaria.MyFile.FileName;
                client.BaseAddress = new Uri("https://localhost:44357/api/Veterinaria");
                
                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + veterinaria.Id, veterinaria);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Detalles");
                }
            }
            return View(veterinaria);
        }

        public IActionResult Detalles(int id)
        {
            Veterinaria veterinaria = null;
            using (var client = new HttpClient())
            {
                id = int.Parse(HttpContext.Session.GetString("Id"));

                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("veterinaria/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Veterinaria>();
                    readtask.Wait();
                    veterinaria = readtask.Result;
                }
            }

            return View(veterinaria);
        }

        public IActionResult Details(int id)
        {
            Veterinaria veterinaria = null;
            using (var client = new HttpClient())
            {
              
                id = int.Parse(HttpContext.Session.GetString("Id"));
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("veterinaria/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Veterinaria>();
                    readtask.Wait();
                    veterinaria = readtask.Result;
                }
            }

            return View(veterinaria);
        }

        public IActionResult Details_Blog(int id)
        {
            Veterinaria veterinaria = null;
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("veterinaria/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Veterinaria>();
                    readtask.Wait();
                    veterinaria = readtask.Result;
                }
            }

            return View(veterinaria);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("veterinaria/" + id.ToString());


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
