using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using sipsa._Base.Autenticacao;
using sipsa.Models;

namespace sipsa.Controllers
{
    public class LogonController : Controller
    {
        private readonly AutenticacaoUsuario _autenticacaoUsuario;

        public LogonController(AutenticacaoUsuario autenticacaoUsuario)
        {
            _autenticacaoUsuario = autenticacaoUsuario;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                // 1. Autenticação do usuário.
                var usuario = await _autenticacaoUsuario.AutenticarUsuario(login.Email, login.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "Login inválido.");
                    return View();
                }
                else
                {
                    var principal = _autenticacaoUsuario.CriarCookie(usuario);
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
    }
}