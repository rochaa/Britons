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

        public MembroController (IMembroRepositorio membroRepositorio) {
            _membroRepositorio = membroRepositorio;
        }

        public async Task<IActionResult> Index () {
            var membros = await _membroRepositorio.ObterOsUltimosMembrosModificadosAsync() ;
            var membrosModel = membros.Select (u => Mapper.Map<MembroModel> (u)).ToList ();

            return View (membrosModel);
        }
    }
}