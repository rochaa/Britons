using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sipsa.Dominio.Usuarios;
using sipsa.Web.Models;

namespace sipsa.Web.Controllers
{
    [Authorize(Policy = "ADMINISTRADOR")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly UsuarioCadastro _usuarioCadastro;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, UsuarioCadastro usuarioCadastro)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioCadastro = usuarioCadastro;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioRepositorio.ObterTodosAsync();
            var usuariosModel = usuarios.Select(u => Mapper.Map<UsuarioModel>(u)).ToList();

            return View(usuariosModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
                return View();

            usuario.Id = Guid.NewGuid().ToString();
            await _usuarioCadastro.ArmazenarAsync(usuario.Id, usuario.Nome, usuario.Email, usuario.Senha, usuario.Permissao);

            return RedirectToAction("Index");
        }
    }
}