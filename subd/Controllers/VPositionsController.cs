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
    public class VPositionsController : Controller
    {
        private readonly lab610Context _context;

        public VPositionsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.VPositions.ToListAsync());
        }

        // GET: VPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vPosition = await _context.VPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vPosition == null)
            {
                return NotFound();
            }

            return View(vPosition);
        }

        // GET: VPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Position")] VPosition vPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vPosition);
        }

        // GET: VPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vPosition = await _context.VPositions.FindAsync(id);
            if (vPosition == null)
            {
                return NotFound();
            }
            return View(vPosition);
        }

        // POST: VPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position")] VPosition vPosition)
        {
            if (id != vPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VPositionExists(vPosition.Id))
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
            return View(vPosition);
        }

        // GET: VPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vPosition = await _context.VPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vPosition == null)
            {
                return NotFound();
            }

            return View(vPosition);
        }

        // POST: VPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vPosition = await _context.VPositions.FindAsync(id);
            _context.VPositions.Remove(vPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VPositionExists(int id)
        {
            return _context.VPositions.Any(e => e.Id == id);
        }
    }
}
