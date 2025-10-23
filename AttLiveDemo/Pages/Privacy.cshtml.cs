using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttLiveDemo.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public List<Employee>? Employees { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                var file = Path.Combine(Directory.GetCurrentDirectory(), "sampledata.json");
                if (System.IO.File.Exists(file))
                {
                    var json = System.IO.File.ReadAllText(file);
                    Employees = JsonSerializer.Deserialize<List<Employee>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load sample data");
            }
        }
    }

    public class Employee
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime HiringDate { get; set; }
        public string? Department { get; set; }
        public string? JobTitle { get; set; }
    }
}

