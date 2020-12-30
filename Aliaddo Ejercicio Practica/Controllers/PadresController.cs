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
    public class PadresController : Controller
    {
        private readonly Aliaddo_Ejercicio_PracticaContext _context;

        public PadresController(Aliaddo_Ejercicio_PracticaContext context)
        {
            _context = context;
        }

        // GET: Padres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Padre.ToListAsync());
        }

        // GET: Padres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padre
                .FirstOrDefaultAsync(m => m.PadreID == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // GET: Padres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Padres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PadreID,Name,LName,NDocument,Address,Email,PhoneN,Gender,BirthDate,Children")] Padre padre)
        {
            var SiData = _context.Padre.FirstOrDefaultAsync(s => s.Children == Services.THijos.Si);
            if (padre.Children == Services.THijos.Si)
            {
                if (ModelState.IsValid)
            {
                _context.Add(padre);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Hijos");
            }
            }
            if (ModelState.IsValid)
            {
                _context.Add(padre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padre);
        }

        // GET: Padres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padre.FindAsync(id);
            if (padre == null)
            {
                return NotFound();
            }
            return View(padre);
        }

        // POST: Padres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PadreID,Name,LName,NDocument,Address,Email,PhoneN,Gender,BirthDate,Children")] Padre padre)
        {
            if (id != padre.PadreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadreExists(padre.PadreID))
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
            return View(padre);
        }

        // GET: Padres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padre = await _context.Padre
                .FirstOrDefaultAsync(m => m.PadreID == id);
            if (padre == null)
            {
                return NotFound();
            }

            return View(padre);
        }

        // POST: Padres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padre = await _context.Padre.FindAsync(id);
            _context.Padre.Remove(padre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadreExists(int id)
        {
            return _context.Padre.Any(e => e.PadreID == id);
        }
    }
}
