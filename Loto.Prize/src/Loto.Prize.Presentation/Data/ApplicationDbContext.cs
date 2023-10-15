using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Loto.Prize.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JogoModel> Jogo { get; set; }
        public DbSet<VolanteModel>  Volante { get; set; }

    }
}