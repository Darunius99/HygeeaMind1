using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HygeeaMind.Data;
using HygeeaMind.Models;

namespace HygeeaMind.Controllers
{
    public class SpecialistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialistsController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specialists.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specialty,Description,ProfileImageUrl,Email,PhoneNumber,ExperienceYears")] Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialist);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialists.FindAsync(id);
            if (specialist == null)
            {
                return NotFound();
            }
            return View(specialist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialty,Description,ProfileImageUrl,Email,PhoneNumber,ExperienceYears")] Specialist specialist)
        {
            if (id != specialist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialistExists(specialist.Id))
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
            return View(specialist);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialist = await _context.Specialists.FindAsync(id);
            if (specialist != null)
            {
                _context.Specialists.Remove(specialist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialistExists(int id)
        {
            return _context.Specialists.Any(e => e.Id == id);
        }
    }
}
