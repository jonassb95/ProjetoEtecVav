using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Loto.Prize.Domain.Entity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Loto.Prize.Presentation.Controllers
{

    public class VolanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Volante
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var volante = _context.Volante.Where(x=>x.IdUsuario == Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))).ToList();
            return View(volante);
        }

        // GET: Volante/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Volante == null)
            {
                return NotFound();
            }

            var volanteModel = await _context.Volante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volanteModel == null)
            {
                return NotFound();
            }

            return View(volanteModel);
        }

        // GET: Volante/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Jogo = _context.Jogo.OrderByDescending(x => x.DataSorteio).FirstOrDefault(x => x.NumerosSorteados == null);

            if (ViewBag.Jogo == null)
            {
                // Sem jogos a serem jogados.
            }

            return View();
        }

        // POST: Volante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdJogo,NumerosEscolhidos,DataVolante")] VolanteModel volanteModel)
        {
            if (ModelState.IsValid)
            {
                volanteModel.Id = Guid.NewGuid();
                volanteModel.IdUsuario = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                volanteModel.DataVolante = DateTime.Now;

                _context.Add(volanteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volanteModel);
        }

        private bool VolanteModelExists(Guid id)
        {
            return (_context.Volante?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
