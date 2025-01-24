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
    public class EmpleadosController : Controller
    {
        private readonly ConfeccionesElCondorContext _context;

        public EmpleadosController(ConfeccionesElCondorContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var empleados = await _context.Empleados
           .Include(e => e.IdAreaNavigation) // Carga el área relacionada
           .Include(e => e.IdTipoDocumentoNavigation) // Carga el tipo de documento relacionado
           .ToListAsync();

            return View(empleados);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdAreaNavigation)
                .Include(e => e.IdTipoDocumentoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NombreArea");
            ViewData["IdTipoDocumento"] = new SelectList(_context.TiposDocumentos, "IdTipoDocumento", "NombreTipo");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,IdTipoDocumento,NumeroDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,IdArea")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdArea = new SelectList(_context.Areas, "IdArea", "NombreArea", empleado.IdArea);
            ViewBag.IdTipoDocumento = new SelectList(_context.TiposDocumentos, "IdTipoDocumento", "NombreTipo", empleado.IdTipoDocumento);
            return View(empleado);
        }





        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NombreArea", empleado.IdArea);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TiposDocumentos, "IdTipoDocumento", "NombreTipo", empleado.IdTipoDocumento);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,IdTipoDocumento,NumeroDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,IdArea")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "IdArea", "NombreArea", empleado.IdArea);
            ViewData["IdTipoDocumento"] = new SelectList(_context.TiposDocumentos, "IdTipoDocumento", "NombreTipo", empleado.IdTipoDocumento);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdAreaNavigation)
                .Include(e => e.IdTipoDocumentoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}

