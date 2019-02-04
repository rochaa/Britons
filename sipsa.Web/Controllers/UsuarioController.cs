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

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;    
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioRepositorio.ObterTodosAsync();
            var usuariosModel = usuarios.Select(u => Mapper.Map<UsuarioModel>(u)).ToList();

            return View(usuariosModel);
        }
    }
}