using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Sortear()
        {
            /*  
                Sortear 6 números aleatórios entre 01 a 60
                6 números diferentes.
                
             */

            var listaNumerosSorteados = "";

            for (int i = 0; i < 6;)
            {
                var numeroSorteado = new Random().Next(1, 60);

                if (!listaNumerosSorteados.Contains(numeroSorteado.ToString()))
                {
                    if (listaNumerosSorteados.IsNullOrEmpty())
                        listaNumerosSorteados = numeroSorteado.ToString();
                    else
                        listaNumerosSorteados += $";{numeroSorteado}";

                    i++;
                }
            }

            var jogo = _db.Jogo.OrderByDescending(x => x.DataSorteio).FirstOrDefault(x => x.NumerosSorteados != null);

            jogo.NumerosSorteados = listaNumerosSorteados;
            jogo.DataSorteio = DateTime.Now;

            _db.Add(jogo);

            CriarNovoJogo();

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private void CriarNovoJogo()
        {
            var novoJogo = new JogoModel();
            novoJogo.Id = Guid.NewGuid();
            novoJogo.TotalNumero = 60;
            novoJogo.DataCriacao = DateTime.Now;
            novoJogo.QuantidadeNumeroSelecao = 6;
            novoJogo.Nome = "Mega-Sena";
            novoJogo.Premio = "Surpresa";

            _db.Add(novoJogo);
        }

        public IActionResult validarGannhador()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}