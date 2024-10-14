using Microsoft.AspNetCore.Mvc;
using ProyectoSeminarioControlNotas.Models;
using System.Diagnostics;

namespace ProyectoSeminarioControlNotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Politicas()
        {
            return View();
        }
        public IActionResult Acerca()
        {
            return View();
        }

        public IActionResult Alumno()
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
