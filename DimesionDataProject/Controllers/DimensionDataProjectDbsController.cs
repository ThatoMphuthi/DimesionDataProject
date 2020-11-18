using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimesionDataProject.Data;
using DimesionDataProject.Models;

namespace DimesionDataProject.Controllers
{
    public class DimensionDataProjectDbsController : Controller
    {
        private readonly DimensionDataDBContext _context;

        public DimensionDataProjectDbsController(DimensionDataDBContext context)
        {
            _context = context;
        }

        // GET: DimensionDataProjectDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DimensionDataProjectDb.ToListAsync());
        }

        // GET: DimensionDataProjectDbs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionDataProjectDb = await _context.DimensionDataProjectDb
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (dimensionDataProjectDb == null)
            {
                return NotFound();
            }

            return View(dimensionDataProjectDb);
        }

        // GET: DimensionDataProjectDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DimensionDataProjectDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] DimensionDataProjectDb dimensionDataProjectDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimensionDataProjectDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dimensionDataProjectDb);
        }

        // GET: DimensionDataProjectDbs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionDataProjectDb = await _context.DimensionDataProjectDb.FindAsync(id);
            if (dimensionDataProjectDb == null)
            {
                return NotFound();
            }
            return View(dimensionDataProjectDb);
        }

        // POST: DimensionDataProjectDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] DimensionDataProjectDb dimensionDataProjectDb)
        {
            if (id != dimensionDataProjectDb.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimensionDataProjectDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimensionDataProjectDbExists(dimensionDataProjectDb.EmployeeNumber))
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
            return View(dimensionDataProjectDb);
        }

        // GET: DimensionDataProjectDbs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionDataProjectDb = await _context.DimensionDataProjectDb
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (dimensionDataProjectDb == null)
            {
                return NotFound();
            }

            return View(dimensionDataProjectDb);
        }

        // POST: DimensionDataProjectDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dimensionDataProjectDb = await _context.DimensionDataProjectDb.FindAsync(id);
            _context.DimensionDataProjectDb.Remove(dimensionDataProjectDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimensionDataProjectDbExists(string id)
        {
            return _context.DimensionDataProjectDb.Any(e => e.EmployeeNumber == id);
        }
    }
}
