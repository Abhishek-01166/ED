using ED.Data;
using ED.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ED.Controllers;

[Authorize]
public class DashboardController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var today = DateTime.Today;
        var weekStart = today.AddDays(-6);

        var model = new DashboardViewModel
        {
            TotalPatients = await dbContext.Patients.CountAsync(),
            PatientsVisitedToday = await dbContext.Patients.CountAsync(p => p.LastVisitDate.Date == today),
            PatientsVisitedThisWeek = await dbContext.Patients.CountAsync(p => p.LastVisitDate.Date >= weekStart && p.LastVisitDate.Date <= today),
            RecentPatientCount = await dbContext.Patients.CountAsync(p => p.LastVisitDate >= DateTime.UtcNow.AddDays(-30)),
            RecentVisits = await dbContext.Patients
                .OrderByDescending(p => p.LastVisitDate)
                .Take(5)
                .ToListAsync()
        };

        return View(model);
    }
}
