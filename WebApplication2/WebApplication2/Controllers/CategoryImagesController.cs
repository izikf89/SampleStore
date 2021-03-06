using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = nameof(TypeUser.admin))]
    public class CategoryImagesController : Controller
    {
        private readonly WebApplication2Context _context;

        public CategoryImagesController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: CategoryImages
        public async Task<IActionResult> Index()
        {
            var webApplication2Context = _context.CategoryImage.Include(c => c.Category);
            return View(await webApplication2Context.ToListAsync());
        }

        // GET: CategoryImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryImage = await _context.CategoryImage
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryImage == null)
            {
                return NotFound();
            }

            return View(categoryImage);
        }

        // GET: CategoryImages/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name");
            return View();
        }

        // POST: CategoryImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Image")] CategoryImage categoryImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", categoryImage.CategoryId);
            return View(categoryImage);
        }

        // GET: CategoryImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryImage = await _context.CategoryImage.FindAsync(id);
            if (categoryImage == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", categoryImage.CategoryId);
            return View(categoryImage);
        }

        // POST: CategoryImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Image")] CategoryImage categoryImage)
        {
            if (id != categoryImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryImageExists(categoryImage.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", categoryImage.CategoryId);
            return View(categoryImage);
        }

        // GET: CategoryImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryImage = await _context.CategoryImage
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryImage == null)
            {
                return NotFound();
            }

            return View(categoryImage);
        }

        // POST: CategoryImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryImage = await _context.CategoryImage.FindAsync(id);
            _context.CategoryImage.Remove(categoryImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryImageExists(int id)
        {
            return _context.CategoryImage.Any(e => e.Id == id);
        }
    }
}
