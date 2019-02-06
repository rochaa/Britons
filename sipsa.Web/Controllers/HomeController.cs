using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sipsa.Web.Controllers {
    [Authorize]
    public class HomeController : Controller {
        public IActionResult Index () {
            ViewBag.VersionData = Environment.GetEnvironmentVariable ("Version_Data");
            ViewBag.VersionRelease = Environment.GetEnvironmentVariable ("Version_Release");

            return View ();
        }
    }
}