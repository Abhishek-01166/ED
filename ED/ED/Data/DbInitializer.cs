using ED.Models;
using Microsoft.EntityFrameworkCore;

namespace ED.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var hasMigrations = (await context.Database.GetMigrationsAsync()).Any();
        if (hasMigrations)
        {
            await context.Database.MigrateAsync();
        }
        else
        {
            await context.Database.EnsureCreatedAsync();
        }

        if (await context.Patients.AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;
        var patients = new List<Patient>
        {
            new() { PatientCode = "PT-1001", FirstName = "John", LastName = "Carter", Age = 45, Gender = "Male", PhoneNumber = "555-0101", Email = "john.carter@example.com", Address = "12 Pine Street", LastVisitDate = now.AddDays(-1), CreatedAt = now.AddMonths(-3) },
            new() { PatientCode = "PT-1002", FirstName = "Maria", LastName = "Lopez", Age = 29, Gender = "Female", PhoneNumber = "555-0102", Email = "maria.lopez@example.com", Address = "88 Sunset Ave", LastVisitDate = now.AddDays(-4), CreatedAt = now.AddMonths(-5) },
            new() { PatientCode = "PT-1003", FirstName = "Kevin", LastName = "Moore", Age = 53, Gender = "Male", PhoneNumber = "555-0103", Email = "kevin.moore@example.com", Address = "4 Lake Road", LastVisitDate = now.AddDays(-8), CreatedAt = now.AddMonths(-2) },
            new() { PatientCode = "PT-1004", FirstName = "Aisha", LastName = "Khan", Age = 37, Gender = "Female", PhoneNumber = "555-0104", Email = "aisha.khan@example.com", Address = "31 Garden Lane", LastVisitDate = now.AddDays(-2), CreatedAt = now.AddMonths(-4) },
            new() { PatientCode = "PT-1005", FirstName = "Daniel", LastName = "Reed", Age = 61, Gender = "Male", PhoneNumber = "555-0105", Email = "daniel.reed@example.com", Address = "503 Maple Dr", LastVisitDate = now.AddDays(-12), CreatedAt = now.AddMonths(-8) },
            new() { PatientCode = "PT-1006", FirstName = "Sophia", LastName = "Nguyen", Age = 33, Gender = "Female", PhoneNumber = "555-0106", Email = "sophia.nguyen@example.com", Address = "62 Park Blvd", LastVisitDate = now.AddDays(-6), CreatedAt = now.AddMonths(-1) },
            new() { PatientCode = "PT-1007", FirstName = "Omar", LastName = "Hassan", Age = 41, Gender = "Male", PhoneNumber = "555-0107", Email = "omar.hassan@example.com", Address = "77 Cedar Ct", LastVisitDate = now.AddDays(-3), CreatedAt = now.AddMonths(-6) },
            new() { PatientCode = "PT-1008", FirstName = "Priya", LastName = "Patel", Age = 26, Gender = "Female", PhoneNumber = "555-0108", Email = "priya.patel@example.com", Address = "9 Hill Street", LastVisitDate = now.AddDays(-10), CreatedAt = now.AddMonths(-7) },
            new() { PatientCode = "PT-1009", FirstName = "Robert", LastName = "Wells", Age = 48, Gender = "Male", PhoneNumber = "555-0109", Email = "robert.wells@example.com", Address = "215 Forest Ave", LastVisitDate = now.AddDays(-5), CreatedAt = now.AddMonths(-9) },
            new() { PatientCode = "PT-1010", FirstName = "Emily", LastName = "Stone", Age = 39, Gender = "Female", PhoneNumber = "555-0110", Email = "emily.stone@example.com", Address = "19 River Rd", LastVisitDate = now.AddDays(-15), CreatedAt = now.AddMonths(-10) },
            new() { PatientCode = "PT-1011", FirstName = "Liam", LastName = "Brooks", Age = 57, Gender = "Male", PhoneNumber = "555-0111", Email = "liam.brooks@example.com", Address = "541 Cherry St", LastVisitDate = now.AddDays(-7), CreatedAt = now.AddMonths(-4) },
            new() { PatientCode = "PT-1012", FirstName = "Nora", LastName = "Ibrahim", Age = 31, Gender = "Female", PhoneNumber = "555-0112", Email = "nora.ibrahim@example.com", Address = "112 Ocean View", LastVisitDate = now.AddDays(-14), CreatedAt = now.AddMonths(-11) },
            new() { PatientCode = "PT-1013", FirstName = "Ethan", LastName = "Fisher", Age = 22, Gender = "Male", PhoneNumber = "555-0113", Email = "ethan.fisher@example.com", Address = "8 Willow Way", LastVisitDate = now.AddDays(-9), CreatedAt = now.AddMonths(-2) },
            new() { PatientCode = "PT-1014", FirstName = "Grace", LastName = "Miller", Age = 44, Gender = "Female", PhoneNumber = "555-0114", Email = "grace.miller@example.com", Address = "63 Brook St", LastVisitDate = now.AddDays(-11), CreatedAt = now.AddMonths(-3) },
            new() { PatientCode = "PT-1015", FirstName = "Noah", LastName = "James", Age = 35, Gender = "Male", PhoneNumber = "555-0115", Email = "noah.james@example.com", Address = "27 Birch Ave", LastVisitDate = now, CreatedAt = now.AddMonths(-1) }
        };

        context.Patients.AddRange(patients);
        await context.SaveChangesAsync();
    }
}
