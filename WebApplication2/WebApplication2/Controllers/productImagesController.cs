using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class productImagesController : Controller
    {
        private readonly WebApplication2Context _context;

        public productImagesController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: productImages
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return View(await _context.productImage.ToListAsync());

            }

            var productImages = await _context.productImage
               .Where(m => m.ProductId == id.ToString()).ToListAsync();

            if (productImages == null)
            {
                return NotFound();
            }

            return View(productImages);
        }

        // GET: productImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImage = await _context.productImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // GET: productImages/Create
        public IActionResult Create()
        {
            PopulateProductstsDropDownList();
            return View();
        }

        // POST: productImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productImage productImage)
        {
            if (ModelState.IsValid)
            {
                productImage.Image = UploadedFile(productImage);

                _context.Add(productImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(productImage), nameof(Index), int.Parse(productImage.ProductId));
            }
            return View(productImage);
        }

        private string UploadedFile(productImage productImage)
        {
            string relativePath = null;

            if (productImage.img != null)
            {
                string directoryPah = "images/product";
                Directory.CreateDirectory(Path.Combine("wwwroot/", directoryPah));

                relativePath = Path.Combine(directoryPah, productImage.Id + productImage.img.FileName);
                string filePath = Path.Combine("wwwroot/", relativePath);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    productImage.img.CopyTo(fileStream);
                }
            }

            return relativePath;
        }

        private void RemoveImg(string path)
        {
            string filePath = Path.Combine("wwwroot/", path);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }


        // GET: productImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImage = await _context.productImage.FindAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return View(productImage);
        }

        // POST: productImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, productImage productImage)
        {
            if (id != productImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string OldImgPath = (await _context.productImage.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)).Image;

                    RemoveImg(OldImgPath);
                    productImage.Image = UploadedFile(productImage); 
                    
                    _context.Update(productImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productImageExists(productImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = int.Parse(productImage.ProductId)});
            }
            return View(productImage);
        }

        // GET: productImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productImage = await _context.productImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // POST: productImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productImage = await _context.productImage.FindAsync(id);
            RemoveImg(productImage.Image);

            _context.productImage.Remove(productImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productImageExists(int id)
        {
            return _context.productImage.Any(e => e.Id == id);
        }

        private void PopulateProductstsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Prodact
                                   orderby d.Name
                                   select d;
            ViewBag.Products = new SelectList(departmentsQuery, "Id", "Name", selectedDepartment);
        }
    }
}
