using Microsoft.EntityFrameworkCore;
using sipsa.Dominio.Membros;
using sipsa.Dominio.Usuarios;

namespace sipsa.Dados
{
    public class SipsaContexto : DbContext
    {
        public SipsaContexto(DbContextOptions<SipsaContexto> options) : base(options) { }

        public DbSet<Membro> Membros { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}