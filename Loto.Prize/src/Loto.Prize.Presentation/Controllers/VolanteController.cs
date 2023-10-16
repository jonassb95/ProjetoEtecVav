﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loto.Prize.Presentation.Data;
using Loto.Prize.Presentation.Models;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index()
        {
              return _context.Volante != null ? 
                          View(await _context.Volante.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Volante'  is null.");
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
            return View();
        }

        // POST: Volante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdJogo,NumerosEscolhidos,DataVolante")] VolanteModel volanteModel)
        {
            if (ModelState.IsValid)
            {
                volanteModel.Id = Guid.NewGuid();
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