using MerchantApp.Data;
using MerchantApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantApp.Controllers
{
    public class OffersController : Controller
    {
        private readonly MerchantAppContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OffersController(MerchantAppContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var merchantAppContext = _context.Offers.Include(o => o.Merchants).Include(o => o.OfferCategories);
            return View(await merchantAppContext.ToListAsync());
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offers = await _context.Offers
                .Include(o => o.Merchants)
                .Include(o => o.OfferCategories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offers == null)
            {
                return NotFound();
            }

            return View(offers);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["MerchantsId"] = new SelectList(_context.Merchants, "Id", "Id");
            ViewData["OfferCategoriesId"] = new SelectList(_context.OfferCategories, "Id", "Id");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Slug,ImageFile,ImageContentFile,Description,ExpiredAt,FriendRewardType,FriendRewardAmount,FriendRewardIsPercent,FriendRewardExpiredAt,FanRewardType,FanRewardAmount,FanRewardLabel,MerchantsId,OfferCategoriesId,Id,CreatedAt,UpdatedAt")] Offers offers)
        {
            if (ModelState.IsValid)
            {
                offers.Image = UploadImages(offers.ImageFile);
                offers.ImageContent = UploadImages(offers.ImageContentFile);

                _context.Add(offers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MerchantsId"] = new SelectList(_context.Merchants, "Id", "Id", offers.MerchantsId);
            ViewData["OfferCategoriesId"] = new SelectList(_context.OfferCategories, "Id", "Id", offers.OfferCategoriesId);
            return View(offers);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offers = await _context.Offers.FindAsync(id);
            if (offers == null)
            {
                return NotFound();
            }
            ViewData["MerchantsId"] = new SelectList(_context.Merchants, "Id", "Id", offers.MerchantsId);
            ViewData["OfferCategoriesId"] = new SelectList(_context.OfferCategories, "Id", "Id", offers.OfferCategoriesId);
            return View(offers);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Slug,Image,ImageContent,Description,ExpiredAt,FriendRewardType,FriendRewardAmount,FriendRewardIsPercent,FriendRewardExpiredAt,FanRewardType,FanRewardAmount,FanRewardLabel,MerchantsId,OfferCategoriesId,Id,CreatedAt,UpdatedAt")] Offers offers)
        {
            if (id != offers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OffersExists(offers.Id))
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
            ViewData["MerchantsId"] = new SelectList(_context.Merchants, "Id", "Id", offers.MerchantsId);
            ViewData["OfferCategoriesId"] = new SelectList(_context.OfferCategories, "Id", "Id", offers.OfferCategoriesId);
            return View(offers);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offers = await _context.Offers
                .Include(o => o.Merchants)
                .Include(o => o.OfferCategories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offers == null)
            {
                return NotFound();
            }

            return View(offers);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offers = await _context.Offers.FindAsync(id);
            _context.Offers.Remove(offers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OffersExists(int id)
        {
            return _context.Offers.Any(e => e.Id == id);
        }

        private string UploadImages(IFormFile formFile)
        {
            // generate random file name
            string fileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(formFile.FileName));
            // mendefinisikan path
            string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
            // mengcopy file ke path
            using (FileStream stream = System.IO.File.Create(filePath))
            {
                formFile.CopyTo(stream);
            }
            return fileName;
        }
    }
}
