using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly WebApplication2Context _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoriesController(WebApplication2Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        private void GetProducts(Category category)
        {
            var departmentsQuery = from d in _context.Prodact
                                   where d.Categories.All(x => x.CategoryId != category.CategoryId)
                                   orderby d.Name
                                   select d;
            ViewBag.Products = new SelectList(departmentsQuery, "Id", "Name");

            ViewBag.MyProducts = new SelectList(category.Prodacts, "Id", "Name");
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.imgPath = UploadedFile(category);

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(Category category)
        {
            string relativePath = null;

            if (category.img != null)
            {
                string directoryPah = "images/categories";
                Directory.CreateDirectory(Path.Combine("wwwroot/", directoryPah));

                relativePath = Path.Combine(directoryPah, category.CategoryId + category.img.FileName);
                string filePath = Path.Combine("wwwroot/", relativePath);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    category.img.CopyTo(fileStream);
                }
            }

            return relativePath;
        }

        private void RemoveImg(string path)
        {
            string filePath = Path.Combine("wwwroot/", path);
            System.IO.File.Delete(filePath);
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _context.Category.Include(x => x.Prodacts).SingleAsync(x => x.CategoryId == id.Value);

            if (category == null)
                return NotFound();
            
            var task = category.Prodacts.Select(async product => 
                product.Pictuers = (await _context.Prodact.Include(x => x.Pictuers).SingleAsync(m => m.Id == product.Id)).Pictuers
            );

            await Task.WhenAll(task);

            return View(category);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            AddProducts(category);

            if (category == null)
            {
                return NotFound();
            }

            GetProducts(category);
            return View(category);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Category category)
        {
            //AddProducts(category);
            List<Product> prodacts = await _context.Prodact.Where(p => category.ProductIdList.Contains(p.Id)).ToListAsync();
            category.Prodacts = category.Prodacts.Concat(prodacts).ToList();

            _context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = category.CategoryId });
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(Category category)
        {
            //AddProducts(category);
            //category.Prodacts = category.Prodacts.Where(p => !category.ProductIdList.Contains(p.Id)).ToList();
            //var prod = await _context.Prodact.Where(x => category.ProductIdList.Contains(x.Id)).ToListAsync();


            var categoryDb =  _context.Category.Include(x => x.Prodacts).Single(x=> x.CategoryId == category.CategoryId);//   category.CategoryId);
            categoryDb. Prodacts.RemoveAll(x => category.ProductIdList.Contains(x.Id));


            //_context.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = category.CategoryId });
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if(category.img != null)
                    {
                        string OldImgPath = (await _context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == id)).imgPath;

                        RemoveImg(OldImgPath);
                        category.imgPath = UploadedFile(category);
                    }

                    AddProducts(category);

                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            RemoveImg(category.imgPath);

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }

        private void AddProducts(Category category)
        {
            var Query = from d in _context.Category
                        where d.CategoryId == category.CategoryId
                                   select d.Prodacts;
            category.Prodacts = Query.FirstOrDefault();
        }
    }
}
