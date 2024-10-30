using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSeminarioControlNotas.Models;

namespace ProyectoSeminarioControlNotas.Controllers
{
    [Authorize(Roles = "administrador,superadmin,profesor")]
    public class CalificacionController : Controller
    {
        private readonly ProyectoDbContext _context;

        public CalificacionController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: Calificacion
        public async Task<IActionResult> Index()
        {
            var proyectoDbContext = _context.calificaciones.Include(c => c.Alumno).Include(c => c.Curso);
            return View(await proyectoDbContext.ToListAsync());
        }

        // GET: Calificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.calificaciones
                .Include(c => c.Alumno)
                .Include(c => c.Curso)
                .FirstOrDefaultAsync(m => m.idCalificacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // GET: Calificacion/Create
        public IActionResult Create()
        {
            ViewData["idAlumno"] = new SelectList(_context.alumnos, "idAlumno", "nombre");
            ViewData["idCurso"] = new SelectList(_context.cursos, "idCurso", "nombre");
            return View();
        }

        // POST: Calificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCalificacion,estadoCalificacion,idAlumno,idCurso,notaParcialUno,notaParcialDos,notaZona,notaExamen,notaFinal")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                // Calcular la nota final antes de guardar
                calificacion.CalcularNotaFinal();
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAlumno"] = new SelectList(_context.alumnos, "idAlumno", "nombre", calificacion.idAlumno);
            ViewData["idCurso"] = new SelectList(_context.cursos, "idCurso", "nombre", calificacion.idCurso);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.calificaciones.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["idAlumno"] = new SelectList(_context.alumnos, "idAlumno", "nombre", calificacion.idAlumno);
            ViewData["idCurso"] = new SelectList(_context.cursos, "idCurso", "nombre", calificacion.idCurso);
            return View(calificacion);
        }

        // POST: Calificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCalificacion,estadoCalificacion,idAlumno,idCurso,notaParcialUno,notaParcialDos,notaZona,notaExamen,notaFinal")] Calificacion calificacion)
        {
            if (id != calificacion.idCalificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Calcular la nota final antes de guardar
                calificacion.CalcularNotaFinal();
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionExists(calificacion.idCalificacion))
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
            ViewData["idAlumno"] = new SelectList(_context.alumnos, "idAlumno", "nombre", calificacion.idAlumno);
            ViewData["idCurso"] = new SelectList(_context.cursos, "idCurso", "nombre", calificacion.idCurso);
            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.calificaciones
                .Include(c => c.Alumno)
                .Include(c => c.Curso)
                .FirstOrDefaultAsync(m => m.idCalificacion == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificacion = await _context.calificaciones.FindAsync(id);
            if (calificacion != null)
            {
                // Cambia el estadoCalifcacion a false
                calificacion.estadoCalificacion = false;
                // Se modifica el registro y pasaría a ser borrado lógicamente
                _context.calificaciones.Update(calificacion);
                //_context.calificaciones.Remove(calificacion); No usamos el borrado fisico
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionExists(int id)
        {
            return _context.calificaciones.Any(e => e.idCalificacion == id);
        }
    }
}
