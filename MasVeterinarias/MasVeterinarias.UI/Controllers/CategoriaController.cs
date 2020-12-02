using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Categoria> usuario = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("Categoria");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Categoria>>();
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
        public ActionResult Create(Categoria categoria)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/Categoria");
                var posjob = Client.PostAsJsonAsync<Categoria>("categoria", categoria);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(categoria);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Categoria categoria = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("categoria/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Categoria>();
                    readtask.Wait();
                    categoria = readtask.Result;
                }
            }

            return View(categoria);
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
            Categoria categoria = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("categoria/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Categoria>();
                    readtask.Wait();
                    categoria = readtask.Result;
                }
            }

            return View(categoria);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("categoria/" + id.ToString());


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
