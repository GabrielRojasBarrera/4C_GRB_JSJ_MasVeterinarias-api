using Microsoft.AspNetCore.Mvc;

namespace MasVeterinarias.UI.Controllers
{
    public class CitaController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }





        public IActionResult Edit(int id)
        {
            return View();
        }


        public IActionResult Delete(int id)
        {
            return View();
        }




    }
}
