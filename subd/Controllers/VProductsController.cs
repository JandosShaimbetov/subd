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
    public class VProductsController : Controller
    {
        private readonly lab610Context _context;

        public VProductsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.VProducts.ToListAsync());
        }

        // GET: VProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProduct = await _context.VProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vProduct == null)
            {
                return NotFound();
            }

            return View(vProduct);
        }

        // GET: VProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Unit,Quantity,Amount")] VProduct vProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vProduct);
        }

        // GET: VProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProduct = await _context.VProducts.FindAsync(id);
            if (vProduct == null)
            {
                return NotFound();
            }
            return View(vProduct);
        }

        // POST: VProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Unit,Quantity,Amount")] VProduct vProduct)
        {
            if (id != vProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VProductExists(vProduct.Id))
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
            return View(vProduct);
        }

        // GET: VProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProduct = await _context.VProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vProduct == null)
            {
                return NotFound();
            }

            return View(vProduct);
        }

        // POST: VProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vProduct = await _context.VProducts.FindAsync(id);
            _context.VProducts.Remove(vProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VProductExists(int id)
        {
            return _context.VProducts.Any(e => e.Id == id);
        }
    }
}
