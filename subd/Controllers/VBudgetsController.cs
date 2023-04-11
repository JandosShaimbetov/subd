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
    public class VBudgetsController : Controller
    {
        private readonly lab610Context _context;

        public VBudgetsController(lab610Context context)
        {
            _context = context;
        }

        // GET: VBudgets
        public async Task<IActionResult> Index()
        {
            return View(await _context.VBudgets.ToListAsync());
        }

        // GET: VBudgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vBudget = await _context.VBudgets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vBudget == null)
            {
                return NotFound();
            }

            return View(vBudget);
        }

        // GET: VBudgets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VBudgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BudgetAmount")] VBudget vBudget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vBudget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vBudget);
        }

        // GET: VBudgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vBudget = await _context.VBudgets.FindAsync(id);
            if (vBudget == null)
            {
                return NotFound();
            }
            return View(vBudget);
        }

        // POST: VBudgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BudgetAmount")] VBudget vBudget)
        {
            if (id != vBudget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vBudget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VBudgetExists(vBudget.Id))
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
            return View(vBudget);
        }

        // GET: VBudgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vBudget = await _context.VBudgets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vBudget == null)
            {
                return NotFound();
            }

            return View(vBudget);
        }

        // POST: VBudgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vBudget = await _context.VBudgets.FindAsync(id);
            _context.VBudgets.Remove(vBudget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VBudgetExists(int id)
        {
            return _context.VBudgets.Any(e => e.Id == id);
        }
    }
}
