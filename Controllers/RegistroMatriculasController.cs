using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOOLEANDATA.Models;

namespace BOOLEANDATA.Controllers
{
    public class RegistroMatriculasController : Controller
    {
        private readonly BOOLEANDATAContext _context;

        public RegistroMatriculasController(BOOLEANDATAContext context)
        {
            _context = context;
        }

        // GET: RegistroMatriculas
        public async Task<IActionResult> Index()
        {
            var bOOLEANDATAContext = _context.RegistroMatriculas.Include(r => r.IdAcudiente1Navigation).Include(r => r.IdEstudiante1Navigation).Include(r => r.IdPersonaAdmi1Navigation);
            return View(await bOOLEANDATAContext.ToListAsync());
        }

        // GET: RegistroMatriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroMatriculas == null)
            {
                return NotFound();
            }

            var registroMatricula = await _context.RegistroMatriculas
                .Include(r => r.IdAcudiente1Navigation)
                .Include(r => r.IdEstudiante1Navigation)
                .Include(r => r.IdPersonaAdmi1Navigation)
                .FirstOrDefaultAsync(m => m.IdMatricual == id);
            if (registroMatricula == null)
            {
                return NotFound();
            }

            return View(registroMatricula);
        }

        // GET: RegistroMatriculas/Create
        public IActionResult Create()
        {
            ViewData["IdAcudiente1"] = new SelectList(_context.Acudientes, "IdAcudiente", "IdAcudiente");
            ViewData["IdEstudiante1"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante");
            ViewData["IdPersonaAdmi1"] = new SelectList(_context.PersonaAdministrativos, "IdPersonalAdministrativo", "IdPersonalAdministrativo");
            return View();
        }

        // POST: RegistroMatriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMatricual,FechaMatricula,ValorMatricula,IdEstudiante1,IdAcudiente1,IdPersonaAdmi1,Curso")] RegistroMatricula registroMatricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroMatricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAcudiente1"] = new SelectList(_context.Acudientes, "IdAcudiente", "IdAcudiente", registroMatricula.IdAcudiente1);
            ViewData["IdEstudiante1"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", registroMatricula.IdEstudiante1);
            ViewData["IdPersonaAdmi1"] = new SelectList(_context.PersonaAdministrativos, "IdPersonalAdministrativo", "IdPersonalAdministrativo", registroMatricula.IdPersonaAdmi1);
            return View(registroMatricula);
        }

        // GET: RegistroMatriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroMatriculas == null)
            {
                return NotFound();
            }

            var registroMatricula = await _context.RegistroMatriculas.FindAsync(id);
            if (registroMatricula == null)
            {
                return NotFound();
            }
            ViewData["IdAcudiente1"] = new SelectList(_context.Acudientes, "IdAcudiente", "IdAcudiente", registroMatricula.IdAcudiente1);
            ViewData["IdEstudiante1"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", registroMatricula.IdEstudiante1);
            ViewData["IdPersonaAdmi1"] = new SelectList(_context.PersonaAdministrativos, "IdPersonalAdministrativo", "IdPersonalAdministrativo", registroMatricula.IdPersonaAdmi1);
            return View(registroMatricula);
        }

        // POST: RegistroMatriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMatricual,FechaMatricula,ValorMatricula,IdEstudiante1,IdAcudiente1,IdPersonaAdmi1,Curso")] RegistroMatricula registroMatricula)
        {
            if (id != registroMatricula.IdMatricual)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroMatricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroMatriculaExists(registroMatricula.IdMatricual))
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
            ViewData["IdAcudiente1"] = new SelectList(_context.Acudientes, "IdAcudiente", "IdAcudiente", registroMatricula.IdAcudiente1);
            ViewData["IdEstudiante1"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", registroMatricula.IdEstudiante1);
            ViewData["IdPersonaAdmi1"] = new SelectList(_context.PersonaAdministrativos, "IdPersonalAdministrativo", "IdPersonalAdministrativo", registroMatricula.IdPersonaAdmi1);
            return View(registroMatricula);
        }

        // GET: RegistroMatriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroMatriculas == null)
            {
                return NotFound();
            }

            var registroMatricula = await _context.RegistroMatriculas
                .Include(r => r.IdAcudiente1Navigation)
                .Include(r => r.IdEstudiante1Navigation)
                .Include(r => r.IdPersonaAdmi1Navigation)
                .FirstOrDefaultAsync(m => m.IdMatricual == id);
            if (registroMatricula == null)
            {
                return NotFound();
            }

            return View(registroMatricula);
        }

        // POST: RegistroMatriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroMatriculas == null)
            {
                return Problem("Entity set 'BOOLEANDATAContext.RegistroMatriculas'  is null.");
            }
            var registroMatricula = await _context.RegistroMatriculas.FindAsync(id);
            if (registroMatricula != null)
            {
                _context.RegistroMatriculas.Remove(registroMatricula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroMatriculaExists(int id)
        {
          return _context.RegistroMatriculas.Any(e => e.IdMatricual == id);
        }
    }
}
