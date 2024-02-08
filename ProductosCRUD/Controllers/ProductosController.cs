using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductosCRUD.DTOs;
using ProductosCRUD.Models;

namespace ProductosCRUD.Controllers
{
    public class ProductosController : Controller
    {
        private readonly VentasContosoContext _context;

        public ProductosController(VentasContosoContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            //return _context.Productos != null ? 
            //            View(await _context.Productos.ToListAsync()) :
            //            Problem("Entity set 'VentasContosoContext.Productos'  is null.");
            var productos = await _context.Productos
            .Join(
                _context.Subcategorias,
                p => p.Subcategoriakey,
                s => s.Subcategoriakey,
                (p, s) => new ProductosSubCategoriasDTO
                {
                    Productokey = p.Productokey,
                    Nombre = p.Nombre,
                    Descripción = p.Descripción,
                    Subcategoria = s.Subcategoria
                }
            )
            .OrderBy(p => p.Nombre)
            .ToListAsync();

            return View(productos);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Productokey == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            //var subcategorias = _context.Subcategorias.ToList();
            //ViewData["Subcategoriakey"] = new SelectList(subcategorias, "Subcategoriakey", "Subcategoria");

            //return View();

            var ultimoProductoKey = _context.Productos.OrderByDescending(p => p.Productokey).FirstOrDefault()?.Productokey ?? 0;

            // Incrementar el último Productokey en 1 para el nuevo producto
            var nuevoProductoKey = ultimoProductoKey + 1;

            // Obtener la lista de subcategorías
            var subcategorias = _context.Subcategorias.ToList();

            // Crear una SelectList usando los nombres de las subcategorías como valor y la clave de la subcategoría como texto
            ViewData["Subcategoriakey"] = new SelectList(subcategorias, "Subcategoriakey", "Subcategoria");

            // Asignar el nuevo Productokey al modelo
            var nuevoProducto = new Productos { Productokey = nuevoProductoKey };

            return View(nuevoProducto);
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Productokey,Nombre,Descripción,Subcategoriakey,Manufactura,Marca,Claseid,Nombreclase,Coloid,Color,Medida,Tamaño,Costo,Precio")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Productokey,Nombre,Descripción,Subcategoriakey,Manufactura,Marca,Claseid,Nombreclase,Coloid,Color,Medida,Tamaño,Costo,Precio")] Productos productos)
        {
            if (id != productos.Productokey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.Productokey))
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
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Productokey == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'VentasContosoContext.Productos'  is null.");
            }
            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                _context.Productos.Remove(productos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
          return (_context.Productos?.Any(e => e.Productokey == id)).GetValueOrDefault();
        }
    }
}
