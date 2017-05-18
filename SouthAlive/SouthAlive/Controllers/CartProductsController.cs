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
    public class CartProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CartProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CartProduct.Include(c => c.Cart).Include(c => c.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CartProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProduct
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .SingleOrDefaultAsync(m => m.CartProductID == id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            return View(cartProduct);
        }

        // GET: CartProducts/Create
        public IActionResult Create()
        {
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID");
            ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId");
            return View();
        }

        // POST: CartProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartProductID,CartID,ProductID")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartProduct.CartID);
            ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", cartProduct.ProductID);
            return View(cartProduct);
        }

        // GET: CartProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProduct.SingleOrDefaultAsync(m => m.CartProductID == id);
            if (cartProduct == null)
            {
                return NotFound();
            }
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartProduct.CartID);
            ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", cartProduct.ProductID);
            return View(cartProduct);
        }

        // POST: CartProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartProductID,CartID,ProductID")] CartProduct cartProduct)
        {
            if (id != cartProduct.CartProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartProductExists(cartProduct.CartProductID))
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
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartProduct.CartID);
            ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", cartProduct.ProductID);
            return View(cartProduct);
        }

        // GET: CartProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartProduct = await _context.CartProduct
                .Include(c => c.Cart)
                .Include(c => c.Product)
                .SingleOrDefaultAsync(m => m.CartProductID == id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            return View(cartProduct);
        }

        // POST: CartProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartProduct = await _context.CartProduct.SingleOrDefaultAsync(m => m.CartProductID == id);
            _context.CartProduct.Remove(cartProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CartProductExists(int id)
        {
            return _context.CartProduct.Any(e => e.CartProductID == id);
        }
    }
}
