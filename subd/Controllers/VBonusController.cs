using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using subd;

namespace subd.Controllers
{
    public class VBonusController : Controller
    {
        private readonly lab610Context _context;

        public VBonusController(lab610Context context)
        {
            _context = context;
        }

        // GET: VBonus
        public async Task<IActionResult> Index()
        {
            return View(await _context.VBonus.ToListAsync());
        }

        // GET: VBonus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vBonu = await _context.VBonus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vBonu == null)
            {
                return NotFound();
            }

            return View(vBonu);
        }

        // GET: VBonus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VBonus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bonus")] VBonu vBonu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vBonu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vBonu);
        }

        // GET: VBonus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vBonu = await _context.VBonus.FindAsync(id);
            if (vBonu == null)
            {
                return NotFound();
            }
            return View(vBonu);
        }

        // POST: VBonus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bonus")] VBonu vBonu)
        {
            if (id != vBonu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vBonu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VBonuExists(vBonu.Id))
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
            return View(vBonu);
        }

        // GET: VBonus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vBonu = await _context.VBonus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vBonu == null)
            {
                return NotFound();
            }

            return View(vBonu);
        }

        // POST: VBonus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vBonu = await _context.VBonus.FindAsync(id);
            _context.VBonus.Remove(vBonu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VBonuExists(int id)
        {
            return _context.VBonus.Any(e => e.Id == id);
        }
    }
}
