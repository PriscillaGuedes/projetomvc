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
    public class PedidoItemsController : Controller
    {
        private readonly LojaFemmeContext _context;

        public PedidoItemsController(LojaFemmeContext context)
        {
            _context = context;
        }

        // GET: PedidoItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PedidoItem.ToListAsync());
        }

        // GET: PedidoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItem
                .FirstOrDefaultAsync(m => m.PedidoItemId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // GET: PedidoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoItemId,Quantidade,PrecoUnitario")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoItem);
        }

        // GET: PedidoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItem.FindAsync(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }
            return View(pedidoItem);
        }

        // POST: PedidoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoItemId,Quantidade,PrecoUnitario")] PedidoItem pedidoItem)
        {
            if (id != pedidoItem.PedidoItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoItemExists(pedidoItem.PedidoItemId))
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
            return View(pedidoItem);
        }

        // GET: PedidoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoItem = await _context.PedidoItem
                .FirstOrDefaultAsync(m => m.PedidoItemId == id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            return View(pedidoItem);
        }

        // POST: PedidoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoItem = await _context.PedidoItem.FindAsync(id);
            if (pedidoItem != null)
            {
                _context.PedidoItem.Remove(pedidoItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidoItem.Any(e => e.PedidoItemId == id);
        }
    }
}
