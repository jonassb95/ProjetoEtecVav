using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Loto.Prize.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var jogo = _context.Jogo.OrderByDescending(x => x.DataSorteio).FirstOrDefault(x => x.NumerosSorteados != null);
            ViewBag.Jogo = _context.Jogo.OrderByDescending(x => x.DataSorteio).FirstOrDefault(x => x.NumerosSorteados == null);
            
            if (ViewBag.Jogo == null)
            {
                // Sem jogos a serem jogados.
            }

            return View(jogo);
        }

        public IActionResult Listar()
        {
            // Aqui você recuperaria os dados dos volantes do seu banco de dados ou de onde estiverem armazenados
            List<VolanteModel> volantes = _context.Volante.ToList(); // Supondo que você esteja usando o Entity Framework Core e tenha um contexto (_context) configurado

            ViewBag.Volante = volantes;

            return View(); // Retorna a view correspondente
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}