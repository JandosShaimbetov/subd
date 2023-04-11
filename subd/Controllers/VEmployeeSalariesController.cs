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
    public class VEmployeeSalariesController : Controller
    {
        private readonly lab610Context _context;

        public VEmployeeSalariesController(lab610Context context)
        {
            _context = context;
        }

        // GET: VEmployeeSalaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.VEmployeeSalaries.ToListAsync());
        }

        // GET: VEmployeeSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vEmployeeSalary = await _context.VEmployeeSalaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vEmployeeSalary == null)
            {
                return NotFound();
            }

            return View(vEmployeeSalary);
        }

        // GET: VEmployeeSalaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VEmployeeSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Employee,Rawpurchase,Production,Productsales,Quantity,Bonusamount,Amount,Done,Month,Year")] VEmployeeSalary vEmployeeSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vEmployeeSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vEmployeeSalary);
        }

        // GET: VEmployeeSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vEmployeeSalary = await _context.VEmployeeSalaries.FindAsync(id);
            if (vEmployeeSalary == null)
            {
                return NotFound();
            }
            return View(vEmployeeSalary);
        }

        // POST: VEmployeeSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employee,Rawpurchase,Production,Productsales,Quantity,Bonusamount,Amount,Done,Month,Year")] VEmployeeSalary vEmployeeSalary)
        {
            if (id != vEmployeeSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vEmployeeSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VEmployeeSalaryExists(vEmployeeSalary.Id))
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
            return View(vEmployeeSalary);
        }

        // GET: VEmployeeSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vEmployeeSalary = await _context.VEmployeeSalaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vEmployeeSalary == null)
            {
                return NotFound();
            }

            return View(vEmployeeSalary);
        }

        // POST: VEmployeeSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vEmployeeSalary = await _context.VEmployeeSalaries.FindAsync(id);
            _context.VEmployeeSalaries.Remove(vEmployeeSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VEmployeeSalaryExists(int id)
        {
            return _context.VEmployeeSalaries.Any(e => e.Id == id);
        }
    }
}
