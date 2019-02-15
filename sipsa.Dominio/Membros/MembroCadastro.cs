using System.Threading.Tasks;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public class MembroCadastro {
        public static string EmailJaExistente = "Email já cadastrado";
        private readonly IMembroRepositorio _membroRepositorio;

        public MembroCadastro (IMembroRepositorio membroRepositorio) {
            _membroRepositorio = membroRepositorio;
        }

        public async Task ArmazenarAsync (MembroDto membroDto) {
            var membro = await _membroRepositorio.ObterPorIdAsync (membroDto.Id);

            if (membro == null) {
                membro = new Membro (membroDto);
            } else {
                membro.Alterar (membroDto);
            }

            await _membroRepositorio.SalvarAsync (membro);
        }
    }
}