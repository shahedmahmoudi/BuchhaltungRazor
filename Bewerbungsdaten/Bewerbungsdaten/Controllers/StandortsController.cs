using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bewerbungsdaten.Models;

namespace Bewerbungsdaten.Controllers
{
    public class StandortsController : Controller
    {
        private readonly ArbeitssucheContext _context;

        public StandortsController(ArbeitssucheContext context)
        {
            _context = context;
        }

        // GET: Standorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Standort.ToListAsync());
        }

        // GET: Standorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standort = await _context.Standort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (standort == null)
            {
                return NotFound();
            }

            return View(standort);
        }

        // GET: Standorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Standorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Art,ElternId")] Standort standort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standort);
        }

        // GET: Standorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standort = await _context.Standort.FindAsync(id);
            if (standort == null)
            {
                return NotFound();
            }
            return View(standort);
        }

        // POST: Standorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Art,ElternId")] Standort standort)
        {
            if (id != standort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandortExists(standort.Id))
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
            return View(standort);
        }

        // GET: Standorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standort = await _context.Standort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (standort == null)
            {
                return NotFound();
            }

            return View(standort);
        }

        // POST: Standorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standort = await _context.Standort.FindAsync(id);
            _context.Standort.Remove(standort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandortExists(int id)
        {
            return _context.Standort.Any(e => e.Id == id);
        }
    }
}
