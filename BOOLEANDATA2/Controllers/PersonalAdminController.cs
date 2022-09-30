using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOOLEANDATA2.Models;




using Microsoft.AspNetCore.Authorization;

namespace BOOLEANDATA2.Controllers
{
    [Authorize]
    public class PersonalAdminController : Controller
    {
        private readonly BOOLEANDATAContext _context;

        public PersonalAdminController(BOOLEANDATAContext context)
        {
            _context = context;
        }

        // GET: PersonalAdmin
        
        public async Task<IActionResult> Index()
        {
              return View(await _context.PersonalAdmins.ToListAsync());
        }

        // GET: PersonalAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonalAdmins == null)
            {
                return NotFound();
            }

            var personalAdmin = await _context.PersonalAdmins
                .FirstOrDefaultAsync(m => m.IdPerAdm == id);
            if (personalAdmin == null)
            {
                return NotFound();
            }

            return View(personalAdmin);
        }

        // GET: PersonalAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPerAdm,Dni,Rol,Clave,Usuario,Nombre")] PersonalAdmin personalAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalAdmin);
        }

        // GET: PersonalAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonalAdmins == null)
            {
                return NotFound();
            }

            var personalAdmin = await _context.PersonalAdmins.FindAsync(id);
            if (personalAdmin == null)
            {
                return NotFound();
            }
            return View(personalAdmin);
        }

        // POST: PersonalAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPerAdm,Dni,Rol,Clave,Usuario,Nombre")] PersonalAdmin personalAdmin)
        {
            if (id != personalAdmin.IdPerAdm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalAdminExists(personalAdmin.IdPerAdm))
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
            return View(personalAdmin);
        }

        // GET: PersonalAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonalAdmins == null)
            {
                return NotFound();
            }

            var personalAdmin = await _context.PersonalAdmins
                .FirstOrDefaultAsync(m => m.IdPerAdm == id);
            if (personalAdmin == null)
            {
                return NotFound();
            }

            return View(personalAdmin);
        }

        // POST: PersonalAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonalAdmins == null)
            {
                return Problem("Entity set 'BOOLEANDATAContext.PersonalAdmins'  is null.");
            }
            var personalAdmin = await _context.PersonalAdmins.FindAsync(id);
            if (personalAdmin != null)
            {
                _context.PersonalAdmins.Remove(personalAdmin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalAdminExists(int id)
        {
          return _context.PersonalAdmins.Any(e => e.IdPerAdm == id);
        }
    }
}
