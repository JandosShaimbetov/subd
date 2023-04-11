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
    public class VProductionsController : Controller
    {
        private readonly lab610Context _context;

        public VProductionsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VProductions
        public async Task<IActionResult> Index()
        {
            return View(await _context.VProductions.ToListAsync());
        }

        // GET: VProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProduction = await _context.VProductions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vProduction == null)
            {
                return NotFound();
            }

            return View(vProduction);
        }

        // GET: VProductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Quantity,Date,Employee")] VProduction vProduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vProduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vProduction);
        }

        // GET: VProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProduction = await _context.VProductions.FindAsync(id);
            if (vProduction == null)
            {
                return NotFound();
            }
            return View(vProduction);
        }

        // POST: VProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Quantity,Date,Employee")] VProduction vProduction)
        {
            if (id != vProduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vProduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VProductionExists(vProduction.Id))
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
            return View(vProduction);
        }

        // GET: VProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProduction = await _context.VProductions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vProduction == null)
            {
                return NotFound();
            }

            return View(vProduction);
        }

        // POST: VProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vProduction = await _context.VProductions.FindAsync(id);
            _context.VProductions.Remove(vProduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VProductionExists(int id)
        {
            return _context.VProductions.Any(e => e.Id == id);
        }
    }
}
