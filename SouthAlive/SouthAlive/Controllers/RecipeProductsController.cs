using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SouthAlive.Data;
using SouthAlive.Models.PantryModels;

namespace SouthAlive.Controllers
{
    public class RecipeProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: RecipeProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RecipeProduct.Include(r => r.Product).Include(r => r.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RecipeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeProduct = await _context.RecipeProduct
                .Include(r => r.Product)
                .Include(r => r.Recipe)
                .SingleOrDefaultAsync(m => m.RecipeProductID == id);
            if (recipeProduct == null)
            {
                return NotFound();
            }

            return View(recipeProduct);
        }

        // GET: RecipeProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductId", "ProductId");
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID");
            return View();
        }

        // POST: RecipeProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeProductID,RecipeID,ProductID")] RecipeProduct recipeProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductId", "ProductId", recipeProduct.ProductID);
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID", recipeProduct.RecipeID);
            return View(recipeProduct);
        }

        // GET: RecipeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeProduct = await _context.RecipeProduct.SingleOrDefaultAsync(m => m.RecipeProductID == id);
            if (recipeProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductId", "ProductId", recipeProduct.ProductID);
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID", recipeProduct.RecipeID);
            return View(recipeProduct);
        }

        // POST: RecipeProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeProductID,RecipeID,ProductID")] RecipeProduct recipeProduct)
        {
            if (id != recipeProduct.RecipeProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeProductExists(recipeProduct.RecipeProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductId", "ProductId", recipeProduct.ProductID);
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "RecipeID", "RecipeID", recipeProduct.RecipeID);
            return View(recipeProduct);
        }

        // GET: RecipeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeProduct = await _context.RecipeProduct
                .Include(r => r.Product)
                .Include(r => r.Recipe)
                .SingleOrDefaultAsync(m => m.RecipeProductID == id);
            if (recipeProduct == null)
            {
                return NotFound();
            }

            return View(recipeProduct);
        }

        // POST: RecipeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeProduct = await _context.RecipeProduct.SingleOrDefaultAsync(m => m.RecipeProductID == id);
            _context.RecipeProduct.Remove(recipeProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RecipeProductExists(int id)
        {
            return _context.RecipeProduct.Any(e => e.RecipeProductID == id);
        }
    }
}
