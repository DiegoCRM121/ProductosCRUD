using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Models;

namespace ProductosCRUD.Controllers
{
    public class SubcategoriasController : Controller
    {
        private readonly VentasContosoContext _context;

        public SubcategoriasController(VentasContosoContext context)
        {
            _context = context;
        }

        // GET: Subcategorias
        public async Task<IActionResult> Index()
        {
              return _context.Subcategorias != null ? 
                          View(await _context.Subcategorias.ToListAsync()) :
                          Problem("Entity set 'VentasContosoContext.Subcategorias'  is null.");
        }

        // GET: Subcategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subcategorias == null)
            {
                return NotFound();
            }

            var subcategorias = await _context.Subcategorias
                .FirstOrDefaultAsync(m => m.Subcategoriakey == id);
            if (subcategorias == null)
            {
                return NotFound();
            }

            return View(subcategorias);
        }

        // GET: Subcategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subcategoriakey,Subcategoria,Categoriakey")] Subcategorias subcategorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subcategorias);
        }

        // GET: Subcategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subcategorias == null)
            {
                return NotFound();
            }

            var subcategorias = await _context.Subcategorias.FindAsync(id);
            if (subcategorias == null)
            {
                return NotFound();
            }
            return View(subcategorias);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subcategoriakey,Subcategoria,Categoriakey")] Subcategorias subcategorias)
        {
            if (id != subcategorias.Subcategoriakey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriasExists(subcategorias.Subcategoriakey))
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
            return View(subcategorias);
        }

        // GET: Subcategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subcategorias == null)
            {
                return NotFound();
            }

            var subcategorias = await _context.Subcategorias
                .FirstOrDefaultAsync(m => m.Subcategoriakey == id);
            if (subcategorias == null)
            {
                return NotFound();
            }

            return View(subcategorias);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subcategorias == null)
            {
                return Problem("Entity set 'VentasContosoContext.Subcategorias'  is null.");
            }
            var subcategorias = await _context.Subcategorias.FindAsync(id);
            if (subcategorias != null)
            {
                _context.Subcategorias.Remove(subcategorias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriasExists(int id)
        {
          return (_context.Subcategorias?.Any(e => e.Subcategoriakey == id)).GetValueOrDefault();
        }
    }
}
