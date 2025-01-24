using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using confecionesElcondorMVC.Models;

namespace confecionesElcondorMVC.Controllers
{
    public class TiposDocumentosController : Controller
    {
        private readonly ConfeccionesElCondorContext _context;

        public TiposDocumentosController(ConfeccionesElCondorContext context)
        {
            _context = context;
        }

        // GET: TiposDocumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDocumentos.ToListAsync());
        }

        // GET: TiposDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDocumento = await _context.TiposDocumentos
                .FirstOrDefaultAsync(m => m.IdTipoDocumento == id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return View(tiposDocumento);
        }

        // GET: TiposDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoDocumento,NombreTipo")] TiposDocumento tiposDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDocumento);
        }

        // GET: TiposDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }
            return View(tiposDocumento);
        }

        // POST: TiposDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDocumento,NombreTipo")] TiposDocumento tiposDocumento)
        {
            if (id != tiposDocumento.IdTipoDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposDocumentoExists(tiposDocumento.IdTipoDocumento))
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
            return View(tiposDocumento);
        }

        // GET: TiposDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDocumento = await _context.TiposDocumentos
                .FirstOrDefaultAsync(m => m.IdTipoDocumento == id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return View(tiposDocumento);
        }

        // POST: TiposDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);
            if (tiposDocumento != null)
            {
                _context.TiposDocumentos.Remove(tiposDocumento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposDocumentoExists(int id)
        {
            return _context.TiposDocumentos.Any(e => e.IdTipoDocumento == id);
        }
    }
}
