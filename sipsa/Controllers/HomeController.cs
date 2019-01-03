using System;
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
        public IActionResult Index()
        {
            ViewBag.VersionData = Environment.GetEnvironmentVariable("Version_Data");
            ViewBag.VersionRelease = Environment.GetEnvironmentVariable("Version_Release");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Erro { RequisicaoId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
