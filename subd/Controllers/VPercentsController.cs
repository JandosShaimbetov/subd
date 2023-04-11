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
    public class VPercentsController : Controller
    {
        private readonly lab610Context _context;

        public VPercentsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VPercents
        public async Task<IActionResult> Index()
        {
            return View(await _context.VPercents.ToListAsync());
        }

        // GET: VPercents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vPercent = await _context.VPercents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vPercent == null)
            {
                return NotFound();
            }

            return View(vPercent);
        }

        // GET: VPercents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VPercents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Percent")] VPercent vPercent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vPercent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vPercent);
        }

        // GET: VPercents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vPercent = await _context.VPercents.FindAsync(id);
            if (vPercent == null)
            {
                return NotFound();
            }
            return View(vPercent);
        }

        // POST: VPercents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Percent")] VPercent vPercent)
        {
            if (id != vPercent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vPercent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VPercentExists(vPercent.Id))
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
            return View(vPercent);
        }

        // GET: VPercents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vPercent = await _context.VPercents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vPercent == null)
            {
                return NotFound();
            }

            return View(vPercent);
        }

        // POST: VPercents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vPercent = await _context.VPercents.FindAsync(id);
            _context.VPercents.Remove(vPercent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VPercentExists(int id)
        {
            return _context.VPercents.Any(e => e.Id == id);
        }
    }
}
