using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

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
            var jogoTeste = _context.Jogo.OrderByDescending(x => x.DataSorteio).FirstOrDefault(x => x.NumerosSorteados == null);
            ViewBag.Jogo = jogoTeste;


            ViewBag.Volante = _context.Volante.Where(x => x.NumerosEscolhidos != null && x.IdJogo == jogo.Id).ToList();

            if (ViewBag.Jogo == null)
            {
                // Sem jogos a serem jogados.
            }

            return View(jogo);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}