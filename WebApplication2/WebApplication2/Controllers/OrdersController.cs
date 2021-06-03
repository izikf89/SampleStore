using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly WebApplication2Context _context;

        public OrdersController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Orders/ShoppingCart
        public async Task<IActionResult> ShoppingCart()
        {
            int userId = GetUserId();

            Order order = await GetCurrentOrder(userId);

            return RedirectToAction(nameof(Details), new { id = order.Id });
        }

        private int GetUserId()
        {
            return int.Parse(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(int productId)
        {
            int userId = int.Parse(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);

            Product product = await _context.Prodact.FindAsync(productId);

            Order order = await GetCurrentOrder(userId);
            if (order.Prodacts.Contains(product))
                return BadRequest("המוצר כבר קיים בעגלה");

            order.Total = order.Total + product.Price;
            order.Prodacts.Add(product);

            _context.Update(order);
            await _context.SaveChangesAsync();

            return Ok("המוצר נוסף לעגלה בהצלחה.");
        }

        [HttpGet]
        public async Task<IActionResult> FinishOrder(int id)
        {
            int userId = int.Parse(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);

            Product product = await _context.Prodact.FindAsync(id);
            Order order = await GetCurrentOrder(userId);

            order = _context.Order.Include(x => x.Prodacts).Single(x => x.Id == order.Id);
            order.Status = OrderStatuses.WAITING;

            await _context.SaveChangesAsync();

            return RedirectToAction( nameof(Index), "Home", new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> DleleteFromCart(int id)
        {
            int userId = int.Parse(((ClaimsIdentity)User.Identity).FindFirst("Id").Value);

            Product product = await _context.Prodact.FindAsync(id);
            Order order = await GetCurrentOrder(userId);

            order = _context.Order.Include(x => x.Prodacts).Single(x => x.Id == order.Id);
            order.Prodacts.Remove(product);
            order.Total = order.Total - product.Price;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = order.Id });
        }

        public async Task<Order> GetCurrentOrder(int userId)
        {
            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.user.Id == userId && m.Status == OrderStatuses.OPEN);

            if (order == null)
            {
                order = new Order();
                order.user = await _context.User
                    .FirstOrDefaultAsync(u => u.Id == userId);

                _context.Add(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            int userId = GetUserId();

            var order = await _context.Order.Include(o=> o.Prodacts)
                .SingleAsync(m => m.Id == id && m.user.Id == userId);

            await Task.WhenAll(order.Prodacts.Select(async product => {
                var temp = await _context.Prodact.Include(x => x.Pictuers).SingleAsync(m => m.Id == product.Id);
                product.Pictuers = temp.Pictuers;
            }));

            //AddProducts(order);
            if (order == null)
                return NotFound();

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,Status")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [Authorize(Roles = nameof(TypeUser.admin))]
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }

        private void AddProducts(Order order)
        {
            var Query = from d in _context.Order
                        where d.Id == order.Id
                        select d.Prodacts;
            order.Prodacts = Query.FirstOrDefault();
        }
    }
}
