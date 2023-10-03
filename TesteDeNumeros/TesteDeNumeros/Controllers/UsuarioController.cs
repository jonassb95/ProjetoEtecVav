using Microsoft.AspNetCore.Mvc;
using TesteDeNumeros.Data;
using TesteDeNumeros.Models;

namespace TesteDeNumerosLivros.Controllers
{
    public class UsuarioController : Controller
    {

        readonly private ApplicationDbContext _db;

        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<UsuariosModel> usuarios = _db.Usuarios;
            return View(usuarios);
        }

        
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuariosModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.DataCriacao = DateTime.Now;
                usuario.Perfil = TesteDeNumeros.Enums.PerfilEnum.Padrao;
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            UsuariosModel usuario = _db.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]

        public IActionResult Editar(UsuariosModel usuarios)
        {
            if (ModelState.IsValid)
            {
                _db.Usuarios.Update(usuarios);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        [HttpGet]
        public IActionResult ApagarConfirmacao(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            UsuariosModel usuario = _db.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Apagar(int id)
        {
            try
            {
                if (_db.Usuarios.FirstOrDefault(x => x.Id == id)  == null) 
                {
                    return NotFound();
                }

                var apagado = _db.Usuarios.Remove(_db.Usuarios.FirstOrDefault(x => x.Id == id));
                _db.SaveChanges();

                if (_db.SaveChanges() >= 1)  
                    TempData["MensagemSucesso"] = "Usuario Apagado com sucesso!"; 
                else 
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o seu usuário";
            
                return RedirectToAction("Index");
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
