using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreReactLab.DAL;
using CoreReactLab.Models;

namespace CoreReactLab.Controllers
{
    public class TypeWorksController : Controller
    {
        private readonly ApplicationContext _context;

        public TypeWorksController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TypeWorks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeWorks.ToListAsync());
        }

        // GET: TypeWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeWork = await _context.TypeWorks
                .FirstOrDefaultAsync(m => m.id == id);
            if (typeWork == null)
            {
                return NotFound();
            }

            return View(typeWork);
        }

        // GET: TypeWorks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NameWork")] TypeWork typeWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeWork);
        }

        // GET: TypeWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeWork = await _context.TypeWorks.FindAsync(id);
            if (typeWork == null)
            {
                return NotFound();
            }
            return View(typeWork);
        }

        // POST: TypeWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NameWork")] TypeWork typeWork)
        {
            if (id != typeWork.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeWorkExists(typeWork.id))
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
            return View(typeWork);
        }

        // GET: TypeWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeWork = await _context.TypeWorks
                .FirstOrDefaultAsync(m => m.id == id);
            if (typeWork == null)
            {
                return NotFound();
            }

            return View(typeWork);
        }

        // POST: TypeWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeWork = await _context.TypeWorks.FindAsync(id);
            _context.TypeWorks.Remove(typeWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeWorkExists(int id)
        {
            return _context.TypeWorks.Any(e => e.id == id);
        }
    }
}
