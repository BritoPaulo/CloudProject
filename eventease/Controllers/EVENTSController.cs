using eventease.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eventease.Controllers
{
    public class EVENTSController : Controller
    
    {
        private readonly ApplicationDbContext _context;

        public EVENTSController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _context.EVENTS.ToListAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EVENTS events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var events = await _context.EVENTS.FirstOrDefaultAsync(m => m.EVENTS_ID == id);

            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var events = await _context.EVENTS.FirstOrDefaultAsync(m => m.EVENTS_ID == id);

            if (events == null)
            {

                return NotFound();
            }
            return View(events);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var events = await _context.EVENTS.FindAsync(id);
            _context.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(events);

        }

        private bool VenueExists(int id)
        {
            return _context.EVENTS.Any(e => e.EVENTS_ID == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = await _context.EVENTS.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EVENTS events)
        {
            if (id != events.EVENTS_ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(events.EVENTS_ID))
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
            return View(events);
        }
    }
}