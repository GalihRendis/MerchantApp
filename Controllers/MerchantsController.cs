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
    public class MerchantsController : Controller
    {
        private readonly MerchantAppContext _context;

        public MerchantsController(MerchantAppContext context)
        {
            _context = context;
        }

        // GET: Merchants
        public async Task<IActionResult> Index(string MerchantsType, string searchString)
        {
            // Use LINQ to get list of industry types.
            IQueryable<string> IndustryTypeQuery = from m in _context.Merchants
                                            orderby m.IndustryType
                                            select m.IndustryType;

            var merchants = from m in _context.Merchants
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                merchants = merchants.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(MerchantsType))
            {
                merchants = merchants.Where(x => x.IndustryType == MerchantsType);
            }

            var merchantsTypeVM = new MerchantsTypeViewModel
            {
                IndustryType = new SelectList(await IndustryTypeQuery.Distinct().ToListAsync()),
                Merchants = await merchants.ToListAsync()
            };

            return View(merchantsTypeVM);
        }

        // GET: Merchants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchants = await _context.Merchants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchants == null)
            {
                return NotFound();
            }

            return View(merchants);
        }

        // GET: Merchants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OfficialUrl,SenderEmail,Subdomain,IndustryType")] Merchants merchants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchants);
        }

        // GET: Merchants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchants = await _context.Merchants.FindAsync(id);
            if (merchants == null)
            {
                return NotFound();
            }
            return View(merchants);
        }

        // POST: Merchants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,OfficialUrl,SenderEmail,Subdomain,IndustryType")] Merchants merchants)
        {
            if (id != merchants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantsExists(merchants.Id))
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
            return View(merchants);
        }

        // GET: Merchants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchants = await _context.Merchants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchants == null)
            {
                return NotFound();
            }

            return View(merchants);
        }

        // POST: Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchants = await _context.Merchants.FindAsync(id);
            _context.Merchants.Remove(merchants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantsExists(int id)
        {
            return _context.Merchants.Any(e => e.Id == id);
        }
    }
}
