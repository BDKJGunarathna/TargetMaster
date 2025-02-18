using Microsoft.AspNetCore.Mvc;
using TargetMaster.Data;
using TargetMaster.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TargetMaster.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // URI Path Versioning
    [ApiVersion("1.0")]
    public class TargetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TargetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Target/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Target/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Targets target)
        {
            if (ModelState.IsValid)
            {
                // Save the target to the database
                _context.Add(target);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(target);
        }
        // GET: Target/Index
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var targets = _context.Targets.ToList();
            return View(targets);
        }
        // GET: Target/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = await _context.Targets.FindAsync(id);
            if (target == null)
            {
                return NotFound();
            }
            return View(target);
        }
        private bool TargetExists(int id)
        {
            return _context.Targets.Any(e => e.TargetId == id);
        }

        // POST: Target/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Targets target)
        {
            if (id != target.TargetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(target);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!!TargetExists(target.TargetId)) 
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
            return View(target);
        }

        // GET: Target/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var target = await _context.Targets
                .FirstOrDefaultAsync(m => m.TargetId == id);
            if (target == null)
            {
                return NotFound();
            }

            return View(target);
        }


        // POST: Target/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var target = await _context.Targets.FindAsync(id);
            _context.Targets.Remove(target);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
