using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sipsa.Models;
using sipsa.Util;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            usuario.Id = Guid.NewGuid().ToString();
            usuario.Senha = Password.EncryptString(usuario.Senha, Environment.GetEnvironmentVariable("KeyPassword"));
            await db.SaveAsync(usuario);

            return RedirectToAction("Index");
        }
    }
}