using eventease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eventease.Controllers
{
    public class VENUESController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VENUESController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var venues = await _context.VENUES.ToListAsync();
            return View(venues);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VENUES venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var venue = await _context.VENUES.FirstOrDefaultAsync(m => m.VENUES_ID == id);

            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var venue = await _context.VENUES.FirstOrDefaultAsync(m => m.VENUES_ID == id);

            if (venue == null)
            {

                return NotFound();
            }
            return View(venue);
        }
    

    [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _context.VENUES.FindAsync(id);
            _context.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(venue);

        }

        private bool VenueExists(int id)
        {
            return _context.VENUES.Any(e => e.VENUES_ID == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var venue = await _context.VENUES.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VENUES venue)
        {
            if (id != venue.VENUES_ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(venue.VENUES_ID))
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
            return View(venue);
        }
    }
}
