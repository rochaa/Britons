using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using sipsa.Dominio.Usuarios;
using sipsa.Web.Models;

namespace sipsa.Web.Controllers
{
    public class LogonController : Controller
    {
        private readonly UsuarioAutenticacao _usuarioAutenticacao;

        public LogonController(UsuarioAutenticacao usuarioAutenticacao)
        {
            _usuarioAutenticacao = usuarioAutenticacao;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                // 1. Autenticação do usuário.
                var usuario = await _usuarioAutenticacao.Autenticar(login.Email, login.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "Login inválido.");
                    return View();
                }
                else
                {
                    var principal = _usuarioAutenticacao.CriarCookie(usuario);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Logon");
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}