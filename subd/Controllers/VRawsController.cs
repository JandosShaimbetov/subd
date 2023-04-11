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
    public class VRawsController : Controller
    {
        private readonly lab610Context _context;

        public VRawsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VRaws
        public async Task<IActionResult> Index()
        {
            return View(await _context.VRaws.ToListAsync());
        }

        // GET: VRaws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vRaw = await _context.VRaws
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vRaw == null)
            {
                return NotFound();
            }

            return View(vRaw);
        }

        // GET: VRaws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VRaws/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Unit,Quantity,Amount")] VRaw vRaw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vRaw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vRaw);
        }

        // GET: VRaws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vRaw = await _context.VRaws.FindAsync(id);
            if (vRaw == null)
            {
                return NotFound();
            }
            return View(vRaw);
        }

        // POST: VRaws/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Unit,Quantity,Amount")] VRaw vRaw)
        {
            if (id != vRaw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vRaw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VRawExists(vRaw.Id))
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
            return View(vRaw);
        }

        // GET: VRaws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vRaw = await _context.VRaws
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vRaw == null)
            {
                return NotFound();
            }

            return View(vRaw);
        }

        // POST: VRaws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vRaw = await _context.VRaws.FindAsync(id);
            _context.VRaws.Remove(vRaw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VRawExists(int id)
        {
            return _context.VRaws.Any(e => e.Id == id);
        }
    }
}
