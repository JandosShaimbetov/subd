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
    public class VUnitsController : Controller
    {
        private readonly lab610Context _context;

        public VUnitsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.VUnits.ToListAsync());
        }

        // GET: VUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vUnit = await _context.VUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vUnit == null)
            {
                return NotFound();
            }

            return View(vUnit);
        }

        // GET: VUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VUnit vUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vUnit);
        }

        // GET: VUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vUnit = await _context.VUnits.FindAsync(id);
            if (vUnit == null)
            {
                return NotFound();
            }
            return View(vUnit);
        }

        // POST: VUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VUnit vUnit)
        {
            if (id != vUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VUnitExists(vUnit.Id))
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
            return View(vUnit);
        }

        // GET: VUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vUnit = await _context.VUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vUnit == null)
            {
                return NotFound();
            }

            return View(vUnit);
        }

        // POST: VUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vUnit = await _context.VUnits.FindAsync(id);
            _context.VUnits.Remove(vUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VUnitExists(int id)
        {
            return _context.VUnits.Any(e => e.Id == id);
        }
    }
}
