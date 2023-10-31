using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;

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
            var admin = HttpContext.User.IsInRole("admin");

            ViewBag.Admin = admin.ToString().ToLower();

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