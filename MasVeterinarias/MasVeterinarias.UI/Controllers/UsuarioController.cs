using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;

namespace MasVeterinarias.UI.Controllers
{
    public class UsuarioController : Controller
    {

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
        public ActionResult Create(Usuario usuario)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/Usuario");
                var posjob = Client.PostAsJsonAsync<Usuario>("usuario", usuario);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("UserIndex", "Home");
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
