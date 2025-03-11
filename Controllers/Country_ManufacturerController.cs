using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Country_ManufacturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Country_ManufacturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Country_Manufacturer
        public async Task<IActionResult> Index()
        {
            return View(await _context.country_Manufacturers.ToListAsync());
        }

        // GET: Country_Manufacturer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country_Manufacturer = await _context.country_Manufacturers
                .FirstOrDefaultAsync(m => m.idCountryManufacturer == id);
            if (country_Manufacturer == null)
            {
                return NotFound();
            }

            return View(country_Manufacturer);
        }

        // GET: Country_Manufacturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Country_Manufacturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCountryManufacturer,countryManufacturer")] Country_Manufacturer country_Manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country_Manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country_Manufacturer);
        }

        // GET: Country_Manufacturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country_Manufacturer = await _context.country_Manufacturers.FindAsync(id);
            if (country_Manufacturer == null)
            {
                return NotFound();
            }
            return View(country_Manufacturer);
        }

        // POST: Country_Manufacturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCountryManufacturer,countryManufacturer")] Country_Manufacturer country_Manufacturer)
        {
            if (id != country_Manufacturer.idCountryManufacturer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country_Manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Country_ManufacturerExists(country_Manufacturer.idCountryManufacturer))
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
            return View(country_Manufacturer);
        }

        // GET: Country_Manufacturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country_Manufacturer = await _context.country_Manufacturers
                .FirstOrDefaultAsync(m => m.idCountryManufacturer == id);
            if (country_Manufacturer == null)
            {
                return NotFound();
            }

            return View(country_Manufacturer);
        }

        // POST: Country_Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country_Manufacturer = await _context.country_Manufacturers.FindAsync(id);
            if (country_Manufacturer != null)
            {
                _context.country_Manufacturers.Remove(country_Manufacturer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Country_ManufacturerExists(int id)
        {
            return _context.country_Manufacturers.Any(e => e.idCountryManufacturer == id);
        }
    }
}
