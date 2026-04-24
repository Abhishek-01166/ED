using ED.Models;

namespace ED.ViewModels;

public class PatientSearchViewModel
{
    public string? SearchTerm { get; set; }
    public IReadOnlyList<Patient> Results { get; set; } = Array.Empty<Patient>();
}
