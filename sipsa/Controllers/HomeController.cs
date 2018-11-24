using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sipsa.Models;

namespace sipsa.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.VersionData = _configuration["Version:Data"];
            ViewBag.VersionRelease = _configuration["Version:Release"];

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Erro { RequisicaoId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
