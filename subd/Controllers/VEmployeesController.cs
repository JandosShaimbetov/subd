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
    public class VEmployeesController : Controller
    {
        private readonly lab610Context _context;

        public VEmployeesController(lab610Context context)
        {
            _context = context;
        }

        // GET: VEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.VEmployees.ToListAsync());
        }

        // GET: VEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vEmployee = await _context.VEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vEmployee == null)
            {
                return NotFound();
            }

            return View(vEmployee);
        }

        // GET: VEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Employee,Position,Salary,Address,Phone")] VEmployee vEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vEmployee);
        }

        // GET: VEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vEmployee = await _context.VEmployees.FindAsync(id);
            if (vEmployee == null)
            {
                return NotFound();
            }
            return View(vEmployee);
        }

        // POST: VEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employee,Position,Salary,Address,Phone")] VEmployee vEmployee)
        {
            if (id != vEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VEmployeeExists(vEmployee.Id))
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
            return View(vEmployee);
        }

        // GET: VEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vEmployee = await _context.VEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vEmployee == null)
            {
                return NotFound();
            }

            return View(vEmployee);
        }

        // POST: VEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vEmployee = await _context.VEmployees.FindAsync(id);
            _context.VEmployees.Remove(vEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VEmployeeExists(int id)
        {
            return _context.VEmployees.Any(e => e.Id == id);
        }
    }
}
