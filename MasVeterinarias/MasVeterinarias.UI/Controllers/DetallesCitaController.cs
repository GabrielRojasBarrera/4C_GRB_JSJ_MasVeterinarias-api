using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class DetallesCitaController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<DetallesCita> DetallesCita = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("DetallesCita");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<DetallesCita>>();
                    readjob.Wait();
                    DetallesCita = readjob.Result;
                }


            }
            return View(DetallesCita);
        }

        //POST: DetallesCita
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(DetallesCita DetallesCita)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/DetallesCita");
                var posjob = Client.PostAsJsonAsync<DetallesCita>("DetallesCita", DetallesCita);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(DetallesCita);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            DetallesCita DetallesCita = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("DetallesCita/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<DetallesCita>();
                    readtask.Wait();
                    DetallesCita = readtask.Result;
                }
            }

            return View(DetallesCita);
        }


        [HttpPost]
        public ActionResult Edit(DetallesCita DetallesCita)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/DetallesCita");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + DetallesCita.Id, DetallesCita);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(DetallesCita);
        }

        public ActionResult Details(int id)
        {
            DetallesCita DetallesCita = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("DetallesCita/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<DetallesCita>();
                    readtask.Wait();
                    DetallesCita = readtask.Result;
                }
            }

            return View(DetallesCita);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DetallesCita/" + id.ToString());


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
