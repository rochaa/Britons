using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sipsa.Dominio.Membros;
using sipsa.Web.Models;

namespace sipsa.Web.Controllers
{
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
        public IActionResult Create () {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Create (MembroModel membroModel) {
            return await CriarOuAtualizarMembro (membroModel);
        }

        private async Task<IActionResult> CriarOuAtualizarMembro (MembroModel membroModel) {
            if (!ModelState.IsValid)
                return View ();

            var membroDto = Mapper.Map<MembroDto> (membroModel);
            await _membroCadastro.ArmazenarAsync (membroDto);

            return RedirectToAction ("Index");
        }
    }
}