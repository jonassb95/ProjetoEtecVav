using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;

namespace Loto.Prize.Presentation
{
    public class VolanteModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolanteModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VolanteModels
        public async Task<IActionResult> Index()
        {
              return _context.Volante != null ? 
                          View(await _context.Volante.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Volante'  is null.");
        }

        // GET: VolanteModels/Details/5
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

        // GET: VolanteModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VolanteModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdJogo,NumerosEscolhidos,DataVolante")] VolanteModel volanteModel)
        {
            if (ModelState.IsValid)
            {
                volanteModel.Id = Guid.NewGuid();
                _context.Add(volanteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volanteModel);
        }

        // GET: VolanteModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Volante == null)
            {
                return NotFound();
            }

            var volanteModel = await _context.Volante.FindAsync(id);
            if (volanteModel == null)
            {
                return NotFound();
            }
            return View(volanteModel);
        }

        // POST: VolanteModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdUsuario,IdJogo,NumerosEscolhidos,DataVolante")] VolanteModel volanteModel)
        {
            if (id != volanteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volanteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolanteModelExists(volanteModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(volanteModel);
        }

        // GET: VolanteModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: VolanteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Volante == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Volante'  is null.");
            }
            var volanteModel = await _context.Volante.FindAsync(id);
            if (volanteModel != null)
            {
                _context.Volante.Remove(volanteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolanteModelExists(Guid id)
        {
          return (_context.Volante?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
