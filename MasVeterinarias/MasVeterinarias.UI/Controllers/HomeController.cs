using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;


namespace MasVeterinarias.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        //[HttpPost]
        //public ActionResult Index(VeterinariaViewModel model, veterinaria veterinaria)
        //{

        //    if (!string.IsNullOrEmpty(model.Text))
        //    {
        //        model.Veterinarias = model.Veterinarias.FullTextSearchQuery(model.Text);
        //    }
        //    else
        //    {
        //        model.Veterinarias = model.Veterinarias;
        //    }
        //    return View(model);

        //}


        public IActionResult UserIndex()
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

        public IActionResult VIndex()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
