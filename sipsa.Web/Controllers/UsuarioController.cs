using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sipsa.Dominio.Usuarios;
using sipsa.Web.Models;

namespace sipsa.Web.Controllers {
    [Authorize (Policy = "ADMINISTRADOR")]
    public class UsuarioController : Controller {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly UsuarioCadastro _usuarioCadastro;

        public UsuarioController (IUsuarioRepositorio usuarioRepositorio, UsuarioCadastro usuarioCadastro) {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioCadastro = usuarioCadastro;
        }

        public async Task<IActionResult> Index () {
            var usuarios = await _usuarioRepositorio.ObterTodosAsync ();
            var usuariosModel = usuarios.Select (u => Mapper.Map<UsuarioModel> (u)).ToList ();

            return View (usuariosModel);
        }

        [HttpGet]
        public IActionResult Create () {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Create (UsuarioCriacaoModel usuarioCriacaoModel) {
            return await CriarOuAtualizarUsuario (usuarioCriacaoModel.Id, usuarioCriacaoModel.Nome,
                usuarioCriacaoModel.Email, usuarioCriacaoModel.Senha, usuarioCriacaoModel.Permissao);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (string id) {
            return await CarregarUsuarioModel (id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (UsuarioModel usuarioModel) {
            return await CriarOuAtualizarUsuario (usuarioModel.Id, usuarioModel.Nome, usuarioModel.Email,
                null, usuarioModel.Permissao);
        }

        public async Task<IActionResult> Details (string id) {
            return await CarregarUsuarioModel (id);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id) {
            return await CarregarUsuarioModel (id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete (UsuarioModel usuarioModel) {
            if (usuarioModel == null)
                return RedirectToAction ("Index");

            var usuario = Mapper.Map<Usuario> (usuarioModel);
            await _usuarioRepositorio.RemoverAsync (usuario);

            return RedirectToAction ("Index");
        }

        private async Task<IActionResult> CriarOuAtualizarUsuario (string id, string nome, string email, string senha, string permissao) {
            if (!ModelState.IsValid)
                return View ();

            await _usuarioCadastro.ArmazenarAsync (id, nome, email, senha, permissao);

            return RedirectToAction ("Index");
        }

        private async Task<IActionResult> CarregarUsuarioModel (string id) {
            if (string.IsNullOrEmpty (id))
                return RedirectToAction ("Index");

            var usuario = await _usuarioRepositorio.ObterPorIdAsync (id);
            if (usuario == null)
                return RedirectToAction ("Index");

            var usuarioModel = Mapper.Map<UsuarioModel> (usuario);

            return View (usuarioModel);
        }
    }
}