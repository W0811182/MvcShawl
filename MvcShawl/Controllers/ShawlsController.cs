using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShawl.Data;
using MvcShawl.Models;

namespace MvcShawl.Controllers
{
    public class ShawlsController : Controller
    {
        private readonly MvcShawlContext _context;

        public ShawlsController(MvcShawlContext context)
        {
            _context = context;
        }

        // GET: Shawls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shawl.ToListAsync());
        }

        // GET: Shawls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shawl = await _context.Shawl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shawl == null)
            {
                return NotFound();
            }

            return View(shawl);
        }

        // GET: Shawls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shawls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Material,Colour,Price,Description")] Shawl shawl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shawl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shawl);
        }

        // GET: Shawls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shawl = await _context.Shawl.FindAsync(id);
            if (shawl == null)
            {
                return NotFound();
            }
            return View(shawl);
        }

        // POST: Shawls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Material,Colour,Price,Description")] Shawl shawl)
        {
            if (id != shawl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shawl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShawlExists(shawl.Id))
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
            return View(shawl);
        }

        // GET: Shawls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shawl = await _context.Shawl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shawl == null)
            {
                return NotFound();
            }

            return View(shawl);
        }

        // POST: Shawls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shawl = await _context.Shawl.FindAsync(id);
            if (shawl != null)
            {
                _context.Shawl.Remove(shawl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShawlExists(string id)
        {
            return _context.Shawl.Any(e => e.Id == id);
        }
    }
}
