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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString, int? categoryId, int? firmId, int? supplierId)
        {
            // 1. Начинаем с базового запроса.  Важно чтобы был AsQueryable()
            var products = _context.products
                .Include(p => p.Category)
                .Include(p => p.Country_Manufacturer)
                .Include(p => p.Firm)
                .Include(p => p.Material)
                .Include(p => p.Supplier)
                .AsQueryable();

            // 2. Добавляем фильтры, если они переданы.

            // Поиск по имени продукта
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.productName.Contains(searchString));
            }

            // Фильтр по Category
            if (categoryId != null)
            {
                products = products.Where(p => p.idCategory == categoryId);
            }

            // Фильтр по Firm
            if (firmId != null)
            {
                products = products.Where(p => p.idFirm == firmId);
            }

            // Фильтр по Supplier
            if (supplierId != null)
            {
                products = products.Where(p => p.idSupplier == supplierId);
            }

            // 3. Преобразуем в список и передаем в View
            var applicationDbContext = await products.ToListAsync();

            // 4. Передаем значения для фильтров в View, чтобы они отображались в форме.
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "category", categoryId);
            ViewData["idFirm"] = new SelectList(_context.firms, "idFirm", "firm", firmId);
            ViewData["idSupplier"] = new SelectList(_context.suppliers, "idSupplier", "supplier", supplierId);
            ViewData["searchString"] = searchString; // передаем строку поиска для отображения в поле поиска

            return View(applicationDbContext);
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Category)
                .Include(p => p.Country_Manufacturer)
                .Include(p => p.Firm)
                .Include(p => p.Material)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.idProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "category");
            ViewData["idCountryManufacturer"] = new SelectList(_context.country_Manufacturers, "idCountryManufacturer", "countryManufacturer");
            ViewData["idFirm"] = new SelectList(_context.firms, "idFirm", "firm");
            ViewData["idMaterial"] = new SelectList(_context.materials, "idMaterial", "material");
            ViewData["idSupplier"] = new SelectList(_context.suppliers, "idSupplier", "supplier");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProduct,idCategory,idFirm,idSupplier,idMaterial,idCountryManufacturer,productName,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "category", product.idCategory);
            ViewData["idCountryManufacturer"] = new SelectList(_context.country_Manufacturers, "idCountryManufacturer", "countryManufacturer", product.idCountryManufacturer);
            ViewData["idFirm"] = new SelectList(_context.firms, "idFirm", "firm", product.idFirm);
            ViewData["idMaterial"] = new SelectList(_context.materials, "idMaterial", "material", product.idMaterial);
            ViewData["idSupplier"] = new SelectList(_context.suppliers, "idSupplier", "supplier", product.idSupplier);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "category", product.idCategory);
            ViewData["idCountryManufacturer"] = new SelectList(_context.country_Manufacturers, "idCountryManufacturer", "countryManufacturer", product.idCountryManufacturer);
            ViewData["idFirm"] = new SelectList(_context.firms, "idFirm", "firm", product.idFirm);
            ViewData["idMaterial"] = new SelectList(_context.materials, "idMaterial", "material", product.idMaterial);
            ViewData["idSupplier"] = new SelectList(_context.suppliers, "idSupplier", "supplier", product.idSupplier);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProduct,idCategory,idFirm,idSupplier,idMaterial,idCountryManufacturer,productName,Price")] Product product)
        {
            if (id != product.idProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.idProduct))
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
            ViewData["idCategory"] = new SelectList(_context.categories, "idCategory", "category", product.idCategory);
            ViewData["idCountryManufacturer"] = new SelectList(_context.country_Manufacturers, "idCountryManufacturer", "countryManufacturer", product.idCountryManufacturer);
            ViewData["idFirm"] = new SelectList(_context.firms, "idFirm", "firm", product.idFirm);
            ViewData["idMaterial"] = new SelectList(_context.materials, "idMaterial", "material", product.idMaterial);
            ViewData["idSupplier"] = new SelectList(_context.suppliers, "idSupplier", "supplier", product.idSupplier);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Category)
                .Include(p => p.Country_Manufacturer)
                .Include(p => p.Firm)
                .Include(p => p.Material)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.idProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.idProduct == id);
        }
    }
}
