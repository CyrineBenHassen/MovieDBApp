using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;

namespace TP3.Controllers
{
    public class MembreshipTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembreshipTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MembreshipTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MembreshipTypes.ToListAsync());
        }

        // GET: MembreshipTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membreshipType = await _context.MembreshipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membreshipType == null)
            {
                return NotFound();
            }

            return View(membreshipType);
        }

        // GET: MembreshipTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembreshipTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SignUpFee,DurationInMonth,DiscountRate")] MembreshipType membreshipType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membreshipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membreshipType);
        }

        // GET: MembreshipTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membreshipType = await _context.MembreshipTypes.FindAsync(id);
            if (membreshipType == null)
            {
                return NotFound();
            }
            return View(membreshipType);
        }

        // POST: MembreshipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SignUpFee,DurationInMonth,DiscountRate")] MembreshipType membreshipType)
        {
            if (id != membreshipType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membreshipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreshipTypeExists(membreshipType.Id))
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
            return View(membreshipType);
        }

        // GET: MembreshipTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membreshipType = await _context.MembreshipTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membreshipType == null)
            {
                return NotFound();
            }

            return View(membreshipType);
        }

        // POST: MembreshipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membreshipType = await _context.MembreshipTypes.FindAsync(id);
            if (membreshipType != null)
            {
                _context.MembreshipTypes.Remove(membreshipType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreshipTypeExists(int id)
        {
            return _context.MembreshipTypes.Any(e => e.Id == id);
        }
    }
}
