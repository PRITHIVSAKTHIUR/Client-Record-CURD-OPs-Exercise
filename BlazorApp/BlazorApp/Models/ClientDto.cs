using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class ClientDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Status { get; set; } = ""; //May be [ New, Permenant, Lead, Occasional, Inactive]

    }
}
