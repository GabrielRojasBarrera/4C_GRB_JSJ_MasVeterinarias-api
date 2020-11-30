using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasVeterinarias.UI.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Empleado> Empleado = null;
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = Client.GetAsync("Empleado");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<Empleado>>();
                    readjob.Wait();
                    Empleado = readjob.Result;
                }


            }
            return View(Empleado);
        }

        //POST: Empleado
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(Empleado Empleado)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://localhost:44357/api/Empleado");
                var posjob = Client.PostAsJsonAsync<Empleado>("Empleado", Empleado);
                posjob.Wait();

                var postresult = posjob.Result;
                if (postresult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Ha ocurrido un error");
            return View(Empleado);
        }

        // GET: bY Id
        public ActionResult Edit(int id)
        {
            Empleado Empleado = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Empleado/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Empleado>();
                    readtask.Wait();
                    Empleado = readtask.Result;
                }
            }

            return View(Empleado);
        }


        [HttpPost]
        public ActionResult Edit(Empleado Empleado)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/Empleado");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("?id=" + Empleado.Id, Empleado);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Empleado);
        }

        public ActionResult Details(int id)
        {
            Empleado Empleado = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");
                var responseTask = client.GetAsync("Empleado/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Empleado>();
                    readtask.Wait();
                    Empleado = readtask.Result;
                }
            }

            return View(Empleado);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Empleado/" + id.ToString());


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
