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
    public class CursoController : Controller
    {
        private readonly ProyectoDbContext _context;

        public CursoController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: Curso
        public async Task<IActionResult> Index()
        {
            var proyectoDbContext = _context.cursos.Include(c => c.Carrera).Include(c => c.Profesor);
            //Aquí se filtran los registros para que se muestren unicamente los de estado True
            //return View(await _context.cursos.Where(a => a.estadoCurso).ToListAsync());
            return View(await proyectoDbContext.ToListAsync());
        }

        // GET: Curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.cursos
                .Include(c => c.Carrera)
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.idCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            ViewData["idCarrera"] = new SelectList(_context.carreras, "idCarrera", "nombre");
            ViewData["idProfesor"] = new SelectList(_context.profesores, "idProfesor", "nombre");
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCurso,estadoCurso,nombre,codigoCurso,idCarrera,idProfesor")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCarrera"] = new SelectList(_context.carreras, "idCarrera", "nombre", curso.idCarrera);
            ViewData["idProfesor"] = new SelectList(_context.profesores, "idProfesor", "nombre", curso.idProfesor);
            return View(curso);
        }

        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["idCarrera"] = new SelectList(_context.carreras, "idCarrera", "nombre", curso.idCarrera);
            ViewData["idProfesor"] = new SelectList(_context.profesores, "idProfesor", "nombre", curso.idProfesor);
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCurso,estadoCurso,nombre,codigoCurso,idCarrera,idProfesor")] Curso curso)
        {
            if (id != curso.idCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.idCurso))
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
            ViewData["idCarrera"] = new SelectList(_context.carreras, "idCarrera", "nombre", curso.idCarrera);
            ViewData["idProfesor"] = new SelectList(_context.profesores, "idProfesor", "nombre", curso.idProfesor);
            return View(curso);
        }

        // GET: Curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.cursos
                .Include(c => c.Carrera)
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.idCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.cursos.FindAsync(id);
            if (curso != null)
            {
                // Cambia el estadoCurso a false
                curso.estadoCurso = false;
                // Se modifica el registro y pasaría a ser borrado lógicamente
                _context.cursos.Update(curso);
                //_context.cursos.Remove(curso); No usamos el borrado fisico
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.cursos.Any(e => e.idCurso == id);
        }
    }
}
