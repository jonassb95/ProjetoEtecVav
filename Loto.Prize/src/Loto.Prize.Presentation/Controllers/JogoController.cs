using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Loto.Prize.Presentation.Controllers
{
    public class JogoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public JogoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<JogoModel> jogos = _db.Jogo;
            return View(jogos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(JogoModel jogo)
        {
            if (ModelState.IsValid)
            {
                jogo.DataCriacao = DateTime.Now;
                jogo.NumerosSorteados = "03;12;17;26;36;47";
                _db.Jogo.Add(jogo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}