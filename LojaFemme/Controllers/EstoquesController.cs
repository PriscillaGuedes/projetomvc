using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaFemme.Data;
using LojaFemme.Models;

namespace LojaFemme.Controllers
{
    public class EstoquesController : Controller
    {
        private readonly LojaFemmeContext _context;

        public EstoquesController(LojaFemmeContext context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            var lojaFemmeContext = _context.Estoque.Include(e => e.Produto);
            return View(await lojaFemmeContext.ToListAsync());
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            ViewData["ProdutoID"] = new SelectList(_context.Set<Produto>(), "ProdutoId", "Descricao");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstoqueId,ProdutoID,Quantidade,LastUpdated")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoID"] = new SelectList(_context.Set<Produto>(), "ProdutoId", "Descricao", estoque.ProdutoID);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            ViewData["ProdutoID"] = new SelectList(_context.Set<Produto>(), "ProdutoId", "Descricao", estoque.ProdutoID);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstoqueId,ProdutoID,Quantidade,LastUpdated")] Estoque estoque)
        {
            if (id != estoque.EstoqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.EstoqueId))
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
            ViewData["ProdutoID"] = new SelectList(_context.Set<Produto>(), "ProdutoId", "Descricao", estoque.ProdutoID);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque != null)
            {
                _context.Estoque.Remove(estoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoque.Any(e => e.EstoqueId == id);
        }
    }
}
