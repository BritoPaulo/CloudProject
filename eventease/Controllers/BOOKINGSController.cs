using eventease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eventease.Controllers
{
    public class BOOKINGSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BOOKINGSController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.BOOKINGS.ToListAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BOOKINGS bookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookings);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var bookings = await _context.BOOKINGS.FirstOrDefaultAsync(m => m.BOOKINGS_ID == id);

            if (bookings == null)
            {
                return NotFound();
            }
            return View(bookings);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var bookings = await _context.BOOKINGS.FirstOrDefaultAsync(m => m.BOOKINGS_ID == id);

            if (bookings == null)
            {

                return NotFound();
            }
            return View(bookings);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bookings = await _context.BOOKINGS.FindAsync(id);
            _context.Remove(bookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(bookings);

        }

        private bool VenuesExists(int id)
        {
            return _context.BOOKINGS.Any(e => e.BOOKINGS_ID == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookings = await _context.BOOKINGS.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            return View(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BOOKINGS bookings)
        {
            if (id != bookings.BOOKINGS_ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenuesExists(bookings.BOOKINGS_ID))
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
            return View(bookings);
        }
    }
}
