using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlyHigh.Models;

namespace FlyHigh.Controllers
{
    public class PlaneDepartmentsController : Controller
    {
        private readonly FlyHighContext _context;

        public PlaneDepartmentsController(FlyHighContext context)
        {
            _context = context;
        }

        // GET: PlaneDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlaneDepartment.ToListAsync());
        }

        // GET: PlaneDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeDepartment = await _context.PlaneDepartment
                .SingleOrDefaultAsync(m => m.PlaneId == id);
            if (planeDepartment == null)
            {
                return NotFound();
            }

            return View(planeDepartment);
        }

        // GET: PlaneDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaneDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneId,DepartmentId")] PlaneDepartment planeDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planeDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planeDepartment);
        }

        // GET: PlaneDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeDepartment = await _context.PlaneDepartment.SingleOrDefaultAsync(m => m.PlaneId == id);
            if (planeDepartment == null)
            {
                return NotFound();
            }
            return View(planeDepartment);
        }

        // POST: PlaneDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneId,DepartmentId")] PlaneDepartment planeDepartment)
        {
            if (id != planeDepartment.PlaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planeDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneDepartmentExists(planeDepartment.PlaneId))
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
            return View(planeDepartment);
        }

        // GET: PlaneDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planeDepartment = await _context.PlaneDepartment
                .SingleOrDefaultAsync(m => m.PlaneId == id);
            if (planeDepartment == null)
            {
                return NotFound();
            }

            return View(planeDepartment);
        }

        // POST: PlaneDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planeDepartment = await _context.PlaneDepartment.SingleOrDefaultAsync(m => m.PlaneId == id);
            _context.PlaneDepartment.Remove(planeDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneDepartmentExists(int id)
        {
            return _context.PlaneDepartment.Any(e => e.PlaneId == id);
        }
    }
}
