using Microsoft.AspNetCore.Mvc;
using TesteDeNumeros.Data;
using TesteDeNumeros.Models;

namespace TesteDeNumerosLivros.Controllers
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
            IEnumerable<JogosModel> jogos = _db.Jogos;
            return View(jogos);
        }

        public IActionResult FazerJogo(VolantesFeitoModel volantesFeito)
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Cadastrar(EmprestimosModel emprestimos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Emprestimo.Add(emprestimos);
        //        _db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Editar(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    EmprestimosModel emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

        //    if (emprestimo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(emprestimo);
        //}

        //[HttpPost]

        //public IActionResult Editar(EmprestimosModel emprestimo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Emprestimo.Update(emprestimo);
        //        _db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View(emprestimo);
        //}

        //[HttpGet]
        //public IActionResult Excluir(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    EmprestimosModel emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

        //    if (emprestimo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(emprestimo);
        //}

        //[HttpPost]
        //public IActionResult Excluir(EmprestimosModel emprestimo)
        //{
        //    if (emprestimo == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Emprestimo.Remove(emprestimo);
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

    }
}
