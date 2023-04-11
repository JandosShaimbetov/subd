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
    public class VProductSalesController : Controller
    {
        private readonly lab610Context _context;

        public VProductSalesController(lab610Context context)
        {
            _context = context;
        }

        // GET: VProductSales
        public async Task<IActionResult> Index()
        {
            return View(await _context.VProductSales.ToListAsync());
        }

        // GET: VProductSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProductSale = await _context.VProductSales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vProductSale == null)
            {
                return NotFound();
            }

            return View(vProductSale);
        }

        // GET: VProductSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VProductSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Quantity,Amount,Date,Employee")] VProductSale vProductSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vProductSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vProductSale);
        }

        // GET: VProductSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProductSale = await _context.VProductSales.FindAsync(id);
            if (vProductSale == null)
            {
                return NotFound();
            }
            return View(vProductSale);
        }

        // POST: VProductSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Quantity,Amount,Date,Employee")] VProductSale vProductSale)
        {
            if (id != vProductSale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vProductSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VProductSaleExists(vProductSale.Id))
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
            return View(vProductSale);
        }

        // GET: VProductSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vProductSale = await _context.VProductSales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vProductSale == null)
            {
                return NotFound();
            }

            return View(vProductSale);
        }

        // POST: VProductSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vProductSale = await _context.VProductSales.FindAsync(id);
            _context.VProductSales.Remove(vProductSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VProductSaleExists(int id)
        {
            return _context.VProductSales.Any(e => e.Id == id);
        }
    }
}
