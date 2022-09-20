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
    public class AcudientesController : Controller
    {
        private readonly BOOLEANDATAContext _context;

        public AcudientesController(BOOLEANDATAContext context)
        {
            _context = context;
        }

        // GET: Acudientes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Acudientes.ToListAsync());
        }

        // GET: Acudientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acudientes == null)
            {
                return NotFound();
            }

            var acudiente = await _context.Acudientes
                .FirstOrDefaultAsync(m => m.IdAcudiente == id);
            if (acudiente == null)
            {
                return NotFound();
            }

            return View(acudiente);
        }

        // GET: Acudientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acudientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAcudiente,Dni,TipoDocumento,NombreApellidos,FechaNacimiento,DireccionCasa,TelefonoCasa,TelefonoOpcional,Genero,Email,Contraseña,Ocupacion,Parentesco,DireccionTrabajo")] Acudiente acudiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acudiente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acudiente);
        }

        // GET: Acudientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acudientes == null)
            {
                return NotFound();
            }

            var acudiente = await _context.Acudientes.FindAsync(id);
            if (acudiente == null)
            {
                return NotFound();
            }
            return View(acudiente);
        }

        // POST: Acudientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAcudiente,Dni,TipoDocumento,NombreApellidos,FechaNacimiento,DireccionCasa,TelefonoCasa,TelefonoOpcional,Genero,Email,Contraseña,Ocupacion,Parentesco,DireccionTrabajo")] Acudiente acudiente)
        {
            if (id != acudiente.IdAcudiente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acudiente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcudienteExists(acudiente.IdAcudiente))
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
            return View(acudiente);
        }

        // GET: Acudientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acudientes == null)
            {
                return NotFound();
            }

            var acudiente = await _context.Acudientes
                .FirstOrDefaultAsync(m => m.IdAcudiente == id);
            if (acudiente == null)
            {
                return NotFound();
            }

            return View(acudiente);
        }

        // POST: Acudientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Acudientes == null)
            {
                return Problem("Entity set 'BOOLEANDATAContext.Acudientes'  is null.");
            }
            var acudiente = await _context.Acudientes.FindAsync(id);
            if (acudiente != null)
            {
                _context.Acudientes.Remove(acudiente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcudienteExists(int id)
        {
          return _context.Acudientes.Any(e => e.IdAcudiente == id);
        }
    }
}
