using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bewerbungsdaten.Models;
using Bewerbungsdaten.Data;
using Bewerbungsdaten.ModelView;

namespace Bewerbungsdaten.Controllers
{
    public class BewerbungsController : Controller
    {
        private readonly ArbeitssucheContext _context;

        public BewerbungsController(ArbeitssucheContext context)
        {
            _context = context;
        }







        [HttpGet]
        public ActionResult GetStadt(int id)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                var repo = new StadtRepository(_context);

                IEnumerable<SelectListItem> Stadts = repo.GetStadt(id);
                return Json(Stadts);
            }
            return null;
        }



        // GET: Bewerbungs
        public async Task<IActionResult> Index()
        {
            var repo = new BewerbungRepository(_context);
            var myTask = Task.Run(() => repo.GetBewerbungList());
            List<BewerbungDetail> result = await myTask;

            return View(result);
        }

        // GET: Bewerbungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bewerbung = await _context.Bewerbung
                .Include(b => b.Standort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bewerbung == null)
            {
                return NotFound();
            }

            return View(bewerbung);
        }

        // GET: Bewerbungs/Create
        public IActionResult Create()
        {
            var BDet = new BewerbungDetail();
            var Stad = new StadtRepository(_context);

            BDet.Stadts = Stad.GetStadt();
            BDet.Zustands = Stad.GetStandortZustandList();
            
            return View(BDet);
        }

        // POST: Bewerbungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameDerFirma,Berufsbezeichnung,StandortId,Adresse,Telefon,Anforderungsdatum,Wiederholungsdatum,Ergebnis,Webseite,Art,Status")] Bewerbung bewerbung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bewerbung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StandortId"] = new SelectList(_context.Standort, "Id", "Id", bewerbung.StandortId);
            return View(bewerbung);
        }

        // GET: Bewerbungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bewerbung = await _context.Bewerbung.FindAsync(id);
            if (bewerbung == null)
            {
                return NotFound();
            }
            ViewData["StandortId"] = new SelectList(_context.Standort, "Id", "Id", bewerbung.StandortId);
            return View(bewerbung);
        }

        // POST: Bewerbungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameDerFirma,Berufsbezeichnung,StandortId,Adresse,Telefon,Anforderungsdatum,Wiederholungsdatum,Ergebnis,Webseite,Art,Status")] Bewerbung bewerbung)
        {
            if (id != bewerbung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bewerbung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BewerbungExists(bewerbung.Id))
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
            ViewData["StandortId"] = new SelectList(_context.Standort, "Id", "Id", bewerbung.StandortId);
            return View(bewerbung);
        }

        // GET: Bewerbungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bewerbung = await _context.Bewerbung
                .Include(b => b.Standort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bewerbung == null)
            {
                return NotFound();
            }

            return View(bewerbung);
        }

        // POST: Bewerbungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bewerbung = await _context.Bewerbung.FindAsync(id);
            _context.Bewerbung.Remove(bewerbung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BewerbungExists(int id)
        {
            return _context.Bewerbung.Any(e => e.Id == id);
        }
    }
}
