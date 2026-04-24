using ED.Models;
using Microsoft.EntityFrameworkCore;

namespace ED.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
}
