using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSeminarioControlNotas.Models;

namespace ProyectoSeminarioControlNotas.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ProyectoDbContext _context;

        public AlumnoController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: Alumno
        public async Task<IActionResult> Index()
        {
            //Aquí se filtran los registros para que se muestren unicamente los de estado True
            return View(await _context.alumnos.Where(a=>a.estadoAlumno).ToListAsync());
        }

        // GET: Alumno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.alumnos
                .FirstOrDefaultAsync(m => m.idAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlumno,estadoAlumno,nombre,apellido,carrera,correo,numeroTelefono,fechaNacimiento")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlumno,estadoAlumno,nombre,apellido,carrera,correo,numeroTelefono,fechaNacimiento")] Alumno alumno)
        {
            if (id != alumno.idAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.idAlumno))
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
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.alumnos
                .FirstOrDefaultAsync(m => m.idAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.alumnos.FindAsync(id);
            if (alumno != null)
            {
                // Cambia el estadoAlumno a false
                alumno.estadoAlumno = false;
                // Se modifica el registro y pasaría a ser borrado lógicamente
                _context.alumnos.Update(alumno);
                //_context.alumnos.Remove(alumno); No usamos el borrado fisico
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.alumnos.Any(e => e.idAlumno == id);
        }
    }
}
