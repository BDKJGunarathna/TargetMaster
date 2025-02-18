using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TargetMaster.Data;
using TargetMaster.Models;
using System.Threading.Tasks;
namespace TargetMaster.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // URI Path Versioning
    [ApiVersion("1.0")]
    public class PerformanceEvaluationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerformanceEvaluationController(ApplicationDbContext context)
        {
             _context = context;
        }
        // GET: PerformanceEvaluation/Index
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var totalCount = await _context.Employees.CountAsync();

           /* var evaluations = _context.PerformanceEvaluations
                                      .Include(e => e.Employee)
                                      .ToList();*/
           var performanceEvaluations = await _context.PerformanceEvaluations
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new PagedResult<PerformanceEvaluations>(performanceEvaluations, totalCount, page, pageSize);
            return View(result);
        }
        // GET: PerformanceEvaluation/Create
        public IActionResult Create()
        {
            // Get the list of employees for the dropdown
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        // POST: PerformanceEvaluation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationId,EmployeeId,Progress,DateUpdated")] PerformanceEvaluations evaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = _context.Employees.ToList(); // Re-populate employees in case of validation errors
            return View(evaluation);
        }

        // GET: PerformanceEvaluation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.PerformanceEvaluations
                                           .Include(e => e.Employee)
                                           .FirstOrDefaultAsync(e => e.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            ViewBag.Employees = _context.Employees.ToList(); // For employee selection dropdown
            return View(evaluation);
        }

        private bool PerformanceEvaluationExists(int id)
        {
            return _context.PerformanceEvaluations.Any(e => e.EvaluationId == id);
        }

        // POST: PerformanceEvaluation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationId,EmployeeId,Progress,DateUpdated")] PerformanceEvaluations evaluation)
        {
            if (id != evaluation.EvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformanceEvaluationExists(evaluation.EvaluationId))
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

            ViewBag.Employees = _context.Employees.ToList(); // Re-populate employees
            return View(evaluation);
        }

        // GET: PerformanceEvaluation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.PerformanceEvaluations
                                           .Include(e => e.Employee)
                                           .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: PerformanceEvaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.PerformanceEvaluations.FindAsync(id);
            _context.PerformanceEvaluations.Remove(evaluation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
