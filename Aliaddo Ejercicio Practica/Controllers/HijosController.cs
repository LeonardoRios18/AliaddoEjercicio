using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aliaddo_Ejercicio_Practica.Models;

namespace Aliaddo_Ejercicio_Practica.Controllers
{
    public class HijosController : Controller
    {
        private readonly Aliaddo_Ejercicio_PracticaContext _context;

        public HijosController(Aliaddo_Ejercicio_PracticaContext context)
        {
            _context = context;
        }

        // GET: Hijos
        public async Task<IActionResult> Index()
        {
            var aliaddo_Ejercicio_PracticaContext = _context.Hijo.Include(h => h.Padre);
            return View(await aliaddo_Ejercicio_PracticaContext.ToListAsync());
        }

        // GET: Hijos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijo
                .Include(h => h.Padre)
                .FirstOrDefaultAsync(m => m.HijoID == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // GET: Hijos/Create
        public IActionResult Create()
        {
            ViewData["PadreID"] = new SelectList(_context.Padre, "PadreID", "NombreCompleto");
            return View();
        }

        // POST: Hijos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HijoID,PadreID,Name,LName,NDocument,Address,Email,PhoneN,Gender,BirthDate")] Hijo hijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PadreID"] = new SelectList(_context.Padre, "PadreID", "NombreCompleto", hijo.PadreID);
            return View(hijo);
        }

        // GET: Hijos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijo.FindAsync(id);
            if (hijo == null)
            {
                return NotFound();
            }
            ViewData["PadreID"] = new SelectList(_context.Padre, "PadreID", "NombreCompleto", hijo.PadreID);
            return View(hijo);
        }

        // POST: Hijos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HijoID,PadreID,Name,LName,NDocument,Address,Email,PhoneN,Gender,BirthDate")] Hijo hijo)
        {
            if (id != hijo.HijoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HijoExists(hijo.HijoID))
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
            ViewData["PadreID"] = new SelectList(_context.Padre, "PadreID", "NombreCompleto", hijo.PadreID);
            return View(hijo);
        }

        // GET: Hijos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijo
                .Include(h => h.Padre)
                .FirstOrDefaultAsync(m => m.HijoID == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // POST: Hijos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hijo = await _context.Hijo.FindAsync(id);
            _context.Hijo.Remove(hijo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HijoExists(int id)
        {
            return _context.Hijo.Any(e => e.HijoID == id);
        }
    }
}
