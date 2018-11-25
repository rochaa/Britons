using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sipsa.Models;

namespace sipsa.Controllers
{
    [Authorize(Policy = "Administrador")]
    public class UsuarioController : Controller
    {
        private readonly DynamoDBContext db;

        public UsuarioController(DynamoDBContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await db.ScanAsync<Usuario>(null).GetRemainingAsync();
            return View(usuarios);
        }
    }
}