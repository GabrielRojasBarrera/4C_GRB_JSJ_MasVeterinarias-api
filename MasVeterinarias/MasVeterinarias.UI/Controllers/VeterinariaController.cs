using MasVeterinarias.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace MasVeterinarias.UI.Controllers
{

    public class VeterinariaController : Controller
    {
        HttpClient client = new HttpClient();
        public async Task<ActionResult> Index()
        {
            string url = "https://localhost:44357/api/Veterinaria";
            var json = await client.GetStringAsync(url);
            var veterinarias = JsonConvert.DeserializeObject<IList<Veterinaria>>(json);
            return View(veterinarias);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            string url = $"https://localhost:44357/api/Veterinaria";
            var json = await client.GetStringAsync(url);
            var veterinaria = JsonConvert.DeserializeObject<List<Veterinaria>>(json);
            var _veterinaria = veterinaria.FirstOrDefault(e => e.Id.Equals(id));
            return View(veterinaria);
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
