using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProdactsController : Controller
    {
        private readonly WebApplication2Context _context;

        public ProdactsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Prodacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prodact.ToListAsync());
        }

        // GET: Prodacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodact = await _context.Prodact
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (prodact == null)
            {
                return NotFound();
            }

            return View(prodact);
        }

        // GET: Prodacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Price")] Prodact prodact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodact);
        }

        // GET: Prodacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodact = await _context.Prodact.FindAsync(id);
            if (prodact == null)
            {
                return NotFound();
            }
            return View(prodact);
        }

        // POST: Prodacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Price")] Prodact prodact)
        {
            if (id != prodact.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdactExists(prodact.ProductId))
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
            return View(prodact);
        }

        // GET: Prodacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodact = await _context.Prodact
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (prodact == null)
            {
                return NotFound();
            }

            return View(prodact);
        }

        // POST: Prodacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodact = await _context.Prodact.FindAsync(id);
            _context.Prodact.Remove(prodact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdactExists(int id)
        {
            return _context.Prodact.Any(e => e.ProductId == id);
        }
    }
}
