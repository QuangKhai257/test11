using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using TEST1.Models;

namespace test1.Controllers
{
    public class studentController : Controller
    {
        private readonly MvcMovieContext _context;

        public studentController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: student
        public async Task<IActionResult> Index()
        {
              return _context.student != null ? 
                          View(await _context.student.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.student'  is null.");
        }

        // GET: student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student = await _context.student
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentID,studentName,Address")] student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student = await _context.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("studentID,studentName,Address")] student student)
        {
            if (id != student.studentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!studentExists(student.studentID))
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
            return View(student);
        }

        // GET: student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.student == null)
            {
                return NotFound();
            }

            var student = await _context.student
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.student == null)
            {
                return Problem("Entity set 'MvcMovieContext.student'  is null.");
            }
            var student = await _context.student.FindAsync(id);
            if (student != null)
            {
                _context.student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool studentExists(string id)
        {
          return (_context.student?.Any(e => e.studentID == id)).GetValueOrDefault();
        }
    }
}
