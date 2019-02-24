using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sipsa.Dominio.Membros;
using sipsa.Web.Models;

namespace sipsa.Web.Controllers {
    [Authorize]
    public class MembroController : Controller {
        private readonly IMembroRepositorio _membroRepositorio;
        private readonly MembroCadastro _membroCadastro;

        public MembroController (IMembroRepositorio membroRepositorio, MembroCadastro membroCadastro) {
            _membroRepositorio = membroRepositorio;
            _membroCadastro = membroCadastro;
        }

        public async Task<IActionResult> Index () {
            var membros = await _membroRepositorio.ObterOsUltimosMembrosModificadosAsync ();
            var membrosModel = membros.Select (u => Mapper.Map<MembroModel> (u)).ToList ();

            return View (membrosModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate (string id) {
            if (string.IsNullOrEmpty (id))
                return View ();

            return await CarregarMembroModel (id);
        }

        [HttpPost]
        [ActionName ("CreateOrUpdate")]
        public async Task<IActionResult> SalvarMembro (MembroModel membroModel) {
            return await CriarOuAtualizarMembro (membroModel);
        }

        public async Task<IActionResult> Details (string id) {
            return await CarregarMembroModel (id);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (string id) {
            return await CarregarMembroModel (id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete (MembroModel membroModel) {
            if (membroModel == null)
                return RedirectToAction ("Index");

            var membro = Mapper.Map<Membro> (membroModel);
            await _membroRepositorio.RemoverAsync (membro);

            return RedirectToAction ("Index");
        }

        private async Task<IActionResult> CriarOuAtualizarMembro (MembroModel membroModel) {
            if (!ModelState.IsValid)
                return View ();

            var membroDto = Mapper.Map<MembroDto> (membroModel);
            await _membroCadastro.ArmazenarAsync (membroDto);

            return RedirectToAction ("Index");
        }

        private async Task<IActionResult> CarregarMembroModel (string id) {
            var membro = await _membroRepositorio.ObterPorIdAsync (id);
            if (membro == null)
                return RedirectToAction ("Index");

            var membroModel = Mapper.Map<MembroModel> (membro);

            return View (membroModel);
        }
    }
}