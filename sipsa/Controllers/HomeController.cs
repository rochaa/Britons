using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sipsa.Models;

namespace sipsa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Erro { RequisicaoId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
