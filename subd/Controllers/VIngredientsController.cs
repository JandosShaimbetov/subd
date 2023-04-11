using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using subd;

namespace subd.Controllers
{
    public class VIngredientsController : Controller
    {
        private readonly lab610Context _context;

        public VIngredientsController(lab610Context context)
        {
            _context = context;
        }

        public ActionResult SelectedIndexChanged(string Id)
        {
            int prodId = Convert.ToInt32(Id);
            var prod = _context.Products.Find(prodId);
            string ingredient = prod.Name;
            var prod_name = new SqlParameter("prod_name", ingredient);
            var vingred = _context.VIngredients
            .FromSqlRaw("EXECUTE dbo.SelectIngredientDropDownList  @prod_name", prod_name)
            .ToList();
            return View(vingred);
        }
        // GET: VIngredients
        public async Task<IActionResult> Index()
        {
            List<Product> ingredients = _context.Products.ToList();
            ViewBag.VIngredientsList = new SelectList(ingredients.Distinct(), "Id", "Name");

            return View(await _context.VIngredients.ToListAsync());
        }

        // GET: VIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIngredient = await _context.VIngredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vIngredient == null)
            {
                return NotFound();
            }

            return View(vIngredient);
        }

        // GET: VIngredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Raw,Quantity")] VIngredient vIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vIngredient);
        }

        // GET: VIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIngredient = await _context.VIngredients.FindAsync(id);
            if (vIngredient == null)
            {
                return NotFound();
            }
            return View(vIngredient);
        }

        // POST: VIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Raw,Quantity")] VIngredient vIngredient)
        {
            if (id != vIngredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VIngredientExists(vIngredient.Id))
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
            return View(vIngredient);
        }

        // GET: VIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIngredient = await _context.VIngredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vIngredient == null)
            {
                return NotFound();
            }

            return View(vIngredient);
        }

        // POST: VIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vIngredient = await _context.VIngredients.FindAsync(id);
            _context.VIngredients.Remove(vIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VIngredientExists(int id)
        {
            return _context.VIngredients.Any(e => e.Id == id);
        }
    }
}
