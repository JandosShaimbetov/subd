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
    public class VRawPurchasesController : Controller
    {
        private readonly lab610Context _context;

        public VRawPurchasesController(lab610Context context)
        {
            _context = context;
        }

        // GET: VRawPurchases
        public async Task<IActionResult> Index()
        {
            return View(await _context.VRawPurchases.ToListAsync());
        }

        // GET: VRawPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vRawPurchase = await _context.VRawPurchases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vRawPurchase == null)
            {
                return NotFound();
            }

            return View(vRawPurchase);
        }

        // GET: VRawPurchases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VRawPurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Raw,Quantity,Amount,Date,Employee")] VRawPurchase vRawPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vRawPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vRawPurchase);
        }

        // GET: VRawPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vRawPurchase = await _context.VRawPurchases.FindAsync(id);
            if (vRawPurchase == null)
            {
                return NotFound();
            }
            return View(vRawPurchase);
        }

        // POST: VRawPurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Raw,Quantity,Amount,Date,Employee")] VRawPurchase vRawPurchase)
        {
            if (id != vRawPurchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vRawPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VRawPurchaseExists(vRawPurchase.Id))
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
            return View(vRawPurchase);
        }

        // GET: VRawPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vRawPurchase = await _context.VRawPurchases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vRawPurchase == null)
            {
                return NotFound();
            }

            return View(vRawPurchase);
        }

        // POST: VRawPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vRawPurchase = await _context.VRawPurchases.FindAsync(id);
            _context.VRawPurchases.Remove(vRawPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VRawPurchaseExists(int id)
        {
            return _context.VRawPurchases.Any(e => e.Id == id);
        }
    }
}
