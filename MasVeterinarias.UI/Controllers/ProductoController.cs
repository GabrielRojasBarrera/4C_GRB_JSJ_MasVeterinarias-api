using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class ProductoController : Controller
    {
        private IWebHostEnvironment _enviroment;

        public ProductoController(IWebHostEnvironment env)
        {
            _enviroment = env;
        }

        public ActionResult Index()
        {
            IEnumerable<Producto> Producto = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Producto>>();
                    readjob.Wait();
                    Producto = readjob.Result;
                }


            }
            return View(Producto);
        }

        //POST: Producto
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Create(Producto producto)
        {
            var filename = System.IO.Path.Combine(_enviroment.ContentRootPath,
                "wwwroot", "Uploads", "Products", producto.ImageProducts.FileName);

            await producto.ImageProducts.CopyToAsync(
               new System.IO.FileStream(filename, System.IO.FileMode.Create));
            using (var Client = new HttpClient())
            {
                producto.Imagen = producto.ImageProducts.FileName;
                producto.VeterinariaId = 1;
                Client.BaseAddress = new Uri("https://localhost:44357/api/Producto");
                var posjob = Client.PostAsJsonAsync<Producto>("Producto", producto);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(producto);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Producto Producto = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Producto/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Producto>();
                    readtask.Wait();
                    Producto = readtask.Result;
                }
            }

            return View(Producto);
        }


        [HttpPost]
        public ActionResult Edit(Producto Producto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/Producto");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + Producto.Id, Producto);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Producto);
        }

        public ActionResult Detalles()
        {
            IEnumerable<Producto> Producto = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Producto>>();
                    readjob.Wait();
                    Producto = readjob.Result;
                }


            }
            return View(Producto);


        }


        public ActionResult Details(int id)
        {
            Producto Producto = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Producto/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Producto>();
                    readtask.Wait();
                    Producto = readtask.Result;
                }
            }

            return View(Producto);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Producto/" + id.ToString());


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
