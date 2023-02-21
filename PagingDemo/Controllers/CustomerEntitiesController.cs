using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagingDemo.Data;
using PagingDemo.Models;

namespace PagingDemo.Controllers
{
    public class CustomerEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerEntities.ToListAsync());
        }

        // GET: CustomerEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.CustomerEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return View(customerEntity);
        }

        // GET: CustomerEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,ContactTitle,ContactName,Country")] CustomerEntity customerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerEntity);
        }

        // GET: CustomerEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.CustomerEntities.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }
            return View(customerEntity);
        }

        // POST: CustomerEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,ContactTitle,ContactName,Country")] CustomerEntity customerEntity)
        {
            if (id != customerEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerEntityExists(customerEntity.Id))
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
            return View(customerEntity);
        }

        // GET: CustomerEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerEntity = await _context.CustomerEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return View(customerEntity);
        }

        // POST: CustomerEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerEntity = await _context.CustomerEntities.FindAsync(id);
            _context.CustomerEntities.Remove(customerEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerEntityExists(int id)
        {
            return _context.CustomerEntities.Any(e => e.Id == id);
        }
    }
}
