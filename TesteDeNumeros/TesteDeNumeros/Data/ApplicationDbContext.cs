using Microsoft.EntityFrameworkCore;
using TesteDeNumeros.Models;

namespace TesteDeNumeros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UsuariosModel> Usuarios { get; set; }
        public DbSet<JogosModel> Jogos { get; set; }
        public DbSet<VolantesFeitoModel> VolantesFeito { get; set; }
    }
}
