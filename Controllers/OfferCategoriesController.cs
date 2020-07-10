using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MerchantApp.Data;
using MerchantApp.Models;

namespace MerchantApp.Controllers
{
    public class OfferCategoriesController : Controller
    {
        private readonly MerchantAppContext _context;

        public OfferCategoriesController(MerchantAppContext context)
        {
            _context = context;
        }

        // GET: OfferCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfferCategories.ToListAsync());
        }

        // GET: OfferCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerCategories = await _context.OfferCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerCategories == null)
            {
                return NotFound();
            }

            return View(offerCategories);
        }

        // GET: OfferCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfferCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Id,CreatedAt,UpdatedAt")] OfferCategories offerCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerCategories);
        }

        // GET: OfferCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerCategories = await _context.OfferCategories.FindAsync(id);
            if (offerCategories == null)
            {
                return NotFound();
            }
            return View(offerCategories);
        }

        // POST: OfferCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Id,CreatedAt,UpdatedAt")] OfferCategories offerCategories)
        {
            if (id != offerCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferCategoriesExists(offerCategories.Id))
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
            return View(offerCategories);
        }

        // GET: OfferCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerCategories = await _context.OfferCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerCategories == null)
            {
                return NotFound();
            }

            return View(offerCategories);
        }

        // POST: OfferCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offerCategories = await _context.OfferCategories.FindAsync(id);
            _context.OfferCategories.Remove(offerCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferCategoriesExists(int id)
        {
            return _context.OfferCategories.Any(e => e.Id == id);
        }
    }
}
